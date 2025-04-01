using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Models;
using Parking_Management.Parking.Persistence.DbContexts;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Api.Controllers
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
        public async Task<ActionResult<IEnumerable<LaneDto>>> GetAll()
        {
            var lanes = await _laneService.GetAllAsync();
            return Ok(lanes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LaneDto>> GetById(int id)
        {
            var lane = await _laneService.GetByIdAsync(id);

            if (lane == null)
                return NotFound();

            return Ok(lane);
        }

        [HttpPost]
        public async Task<ActionResult<LaneDto>> Create(CreateLaneDto createLaneDto)
        {
            var createdLane = await _laneService.CreateAsync(createLaneDto);
            return CreatedAtAction(nameof(GetById), new { id = createdLane.Id }, createdLane);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<LaneDto>> Update(int id, UpdateLaneDto updateLaneDto)
        {
            var updatedLane = await _laneService.UpdateAsync(id, updateLaneDto);

            if (updatedLane == null)
                return NotFound();

            return Ok(updatedLane);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _laneService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
