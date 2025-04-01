using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Persistence.DbContexts;
using Parking_Management.Parking.Application.Models;

namespace Parking_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ParkingManagementContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ParkingManagementContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(Register model)
        {
            if (await _context.Users.AnyAsync(u => u.Username == model.Username))
            {
                return BadRequest("Tên người dùng đã tồn tại.");
            }

            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return BadRequest("Email đã được sử dụng.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Thêm vai trò mặc định cho người dùng mới (ví dụ: "User")
            var defaultRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            if (defaultRole != null)    
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleId = defaultRole.Id
                };
                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();
            }

            return Ok(new { message = "Đăng ký thành công", user = user });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);

            if (user == null)
            {
                return Unauthorized("Tên đăng nhập không tồn tại");
            }

            // Kiểm tra mật khẩu
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("Mật khẩu không đúng");
            }

            // Lấy vai trò của người dùng
            var userRoles = await _context.UserRoles
                .Where(ur => ur.UserId == user.Id)
                .Select(ur => ur.RoleId)
                .ToListAsync();

            var roles = await _context.Roles
                .Where(r => userRoles.Contains(r.Id))
                .Select(r => r.Name)
                .ToListAsync();

            // Lấy quyền từ vai trò
            var permissions = await _context.RolePermissions
                .Where(rp => userRoles.Contains(rp.RoleId))
                .Join(_context.Permissions,
                    rp => rp.PermissionId,
                    p => p.Id,
                    (rp, p) => p.Name)
                .Distinct()
                .ToListAsync();

            // Tạo token
            var token = GenerateJwtToken(user, roles, permissions);

            return Ok(new AuthResponse
            {
                Token = token,
                Username = user.Username,
                Roles = roles,
                Permissions = permissions
            });
        }

        private string GenerateJwtToken(User user, List<string> roles, List<string> permissions)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // Thêm vai trò vào claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Thêm quyền vào claims
            foreach (var permission in permissions)
            {
                claims.Add(new Claim("permission", permission));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}