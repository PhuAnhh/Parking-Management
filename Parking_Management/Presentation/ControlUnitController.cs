using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Domain.Entities;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlUnitController : ControllerBase
    {
        private readonly ParkingManagementContext _context;

        public ControlUnitController(ParkingManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlUnit>>> GetAll()
        {
            return await _context.ControlUnits.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ControlUnit>> GetById(int id)
        {
            var control_unit = await _context.ControlUnits.FirstOrDefaultAsync(i => i.Id == id);

            if (control_unit == null)
            {
                return NotFound("ControlUnit not found");
            }

            return control_unit;
        }

        [HttpPost]
        public async Task<ActionResult<ControlUnit>> Create([FromBody] ControlUnitOnly controlUnitOnly)
        {
            var control_unit = new ControlUnit
            {
                Name = controlUnitOnly.Name,
                Username = controlUnitOnly.Username,
                Password = controlUnitOnly.Password,
                Type = controlUnitOnly.Type,
                ConnectionProtocol = controlUnitOnly.ConnectionProtocol,
                ComputerId = controlUnitOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };

            _context.ControlUnits.Add(control_unit);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = control_unit.Id }, control_unit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ControlUnitOnly controlUnitOnly)
        {
            if (id != controlUnitOnly.Id)
            {
                return BadRequest("ID not found");
            }

            var existingControlUnit = await _context.ControlUnits.FindAsync(id);
            if (existingControlUnit == null)
            {
                return NotFound("ControlUnit not found");
            }

            existingControlUnit.Name = controlUnitOnly.Name;
            existingControlUnit.Username = controlUnitOnly.Username;
            existingControlUnit.Password = controlUnitOnly.Password;
            existingControlUnit.Type = controlUnitOnly.Type;
            existingControlUnit.ConnectionProtocol = controlUnitOnly.ConnectionProtocol;
            existingControlUnit.ComputerId = controlUnitOnly.ComputerId;
            existingControlUnit.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var control_unit = await _context.ControlUnits.FirstOrDefaultAsync(i => i.Id == id);
            if (control_unit == null)
            {
                return NotFound("ControlUnit not found");
            }

            _context.ControlUnits.Remove(control_unit);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
