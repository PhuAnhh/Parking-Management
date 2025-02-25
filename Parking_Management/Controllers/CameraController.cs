using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Models;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ParkingManagementContext _context;

        public CameraController(ParkingManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Camera>>> GetAll()
        {
            return await _context.Cameras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Camera>> GetById(int id)
        {
            var camera = await _context.Cameras.FirstOrDefaultAsync(i => i.Id == id);

            if (camera == null)
            {
                return NotFound("Camera not found");
            }

            return camera;
        }

        [HttpPost]
        public async Task<ActionResult<Camera>> Create([FromBody] CameraOnly cameraOnly)
        {
            var camera = new Camera
            {
                Name = cameraOnly.Name,
                IpAddress = cameraOnly.IpAddress,
                Resolution = cameraOnly.Resolution,
                Type = cameraOnly.Resolution,
                Username = cameraOnly.Username,
                Password = cameraOnly.Password,
                ComputerId = cameraOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Cameras.Add(camera);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = camera.Id }, camera);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CameraOnly camera)
        {
            if (id != camera.Id)
            {
                return BadRequest("ID not found");
            }

            var existingCamera = await _context.Cameras.FindAsync(id);
            if (existingCamera == null)
            {
                return NotFound("Camera not found");
            }

            existingCamera.Name = camera.Name;
            existingCamera.IpAddress = camera.IpAddress;
            existingCamera.Resolution = camera.Resolution;
            existingCamera.Type = camera.Type;
            existingCamera.Username = camera.Username;
            existingCamera.Password = camera.Password;
            existingCamera.ComputerId = camera.ComputerId;
            existingCamera.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var camera = await _context.Cameras.FirstOrDefaultAsync(i => i.Id == id);
            if (camera == null)
            {
                return NotFound("Camera not found");
            }

            _context.Cameras.Remove(camera);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
