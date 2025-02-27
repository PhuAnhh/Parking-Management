using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Domain.Entities;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaneController : ControllerBase
    {
        private readonly ParkingManagementContext _context;

        public LaneController(ParkingManagementContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lane>>> GetAll()
        {
            return await _context.Lanes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lane>> GetById(int id)
        {
            var lane = await _context.Lanes.FirstOrDefaultAsync(i => i.Id == id);

            if (lane == null)
            {
                return NotFound("Lane not found");
            }

            return lane;
        }

        [HttpPost]
        public async Task<ActionResult<Lane>> CreateGate([FromBody] LaneOnly laneOnly)
        {
            var lane = new Lane
            {
                Name = laneOnly.Name,
                Type = laneOnly.Type,
                ComputerId = laneOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Lanes.Add(lane);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = lane.Id }, lane);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGate(int id, [FromBody] LaneOnly lane)
        {
            if (id != lane.Id)
            {
                return BadRequest("ID not found");
            }

            var existingLane = await _context.Lanes.FindAsync(id);
            if (existingLane == null)
            {
                return NotFound("Lane not found");
            }

            existingLane.Name = lane.Name;
            existingLane.Type = lane.Type;
            existingLane.ComputerId = lane.ComputerId;
            existingLane.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lane = await _context.Lanes.FirstOrDefaultAsync(i => i.Id == id);
            if (lane == null)
            {
                return NotFound("Lane not found");
            }

            _context.Lanes.Remove(lane);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
