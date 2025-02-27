using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Domain.Interface;
using Parking_Management.Domain.Entities;
using Parking_Management.Business.Repositories;
using Parking_Management.Business.Services;
using System.Linq;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaneController : ControllerBase
    {
        private readonly ILaneService _laneService;

        public LaneController(ILaneService laneService)
        {
            _laneService = laneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lane>>> GetAll()
        {
            return Ok(await _laneService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lane>> GetById(int id)
        {
            var lane = await _laneService.GetById(id);

            if (lane == null)
            {
                return NotFound("Lane not found");
            }

            return Ok(lane);
        }

        [HttpPost]
        public async Task<ActionResult<Lane>> CreateGate([FromBody] LaneOnly laneOnly)
        {
            var lane = await _laneService.Add(laneOnly);
            return CreatedAtAction(nameof(GetById), new { id = lane.Id }, lane);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGate(int id, [FromBody] LaneOnly laneOnly)
        {
            await _laneService.Update(id, laneOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lane = await _laneService.GetById(id);
            if (lane == null)
            {
                return NotFound("Lane not found");
            }
            await _laneService.Delete(id);

            return NoContent();
        }
    }
}
