using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Models;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GateController : ControllerBase
    {
        private readonly ParkingManagementContext _context;

        public GateController(ParkingManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gate>>> GetAllGates()
        {
            return await _context.Gates.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gate>> GetGateById(int id)
        {
            var gate = await _context.Gates.FirstOrDefaultAsync(i => i.Id == id);

            if (gate == null)
            {
                return NotFound("Gate not found");
            }

            return gate;
        } 
        [HttpPost]
        public async Task<ActionResult<Gate>> CreateGate([FromBody] GateOnly gateOnly)
        {
            var gate = new Gate
            {
                Name = gateOnly.Name,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();

            return Ok();
        }
        


        [HttpPut]
        public async Task<IActionResult> UpdateGate(int id, [FromBody] GateOnly gate)
        {
            if (id != gate.Id)
            {
                return BadRequest("ID not found");
            }

            var existingGate = await _context.Gates.FindAsync(id);
            if (existingGate == null)
            {
                return NotFound("Gate not found");
            }

            existingGate.Name = gate.Name;
            existingGate.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGate(int id)
        {
            var gate = await _context.Gates.FirstOrDefaultAsync(i => i.Id == id);
            if (gate == null)
            {
                return NotFound("Gate not found");
            }

            _context.Gates.Remove(gate);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
