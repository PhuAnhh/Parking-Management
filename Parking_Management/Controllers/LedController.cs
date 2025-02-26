using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Models;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly ParkingManagementContext _context;

        public LedController(ParkingManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Led>>> GetAll()
        {
            return await _context.Leds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Led>> GetById(int id)
        {
            var led = await _context.Leds.FirstOrDefaultAsync(i => i.Id == id);

            if (led == null)
            {
                return NotFound("Led not found");
            }

            return led;
        }

        [HttpPost]
        public async Task<ActionResult<Led>> CreateGate([FromBody] LedOnly ledOnly)
        {
            var led = new Led
            {
                Name = ledOnly.Name,
                ComputerId = ledOnly.ComputerId,
                Type = ledOnly.Type,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Leds.Add(led);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = led.Id }, led);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LedOnly led)
        {
            if (id != led.Id)
            {
                return BadRequest("ID not found");
            }

            var existingLed = await _context.Leds.FindAsync(id);
            if (existingLed == null)
            {
                return NotFound("Led not found");
            }

            existingLed.Name = led.Name;
            existingLed.ComputerId = led.ComputerId;
            existingLed.Type = led.Type;
            existingLed.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var led = await _context.Leds.FirstOrDefaultAsync(i => i.Id == id);
            if (led == null)
            {
                return NotFound("Led not found");
            }

            _context.Leds.Remove(led);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
