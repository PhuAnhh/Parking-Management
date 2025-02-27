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
    public class ControlUnitController : ControllerBase
    {
        private readonly IControlUnitService _controlUnitService;

        public ControlUnitController(IControlUnitService controlUnitService)
        {
            _controlUnitService = controlUnitService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControlUnit>>> GetAll()
        {
            return Ok(await _controlUnitService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ControlUnit>> GetById(int id)
        {
            var controlUnit = await _controlUnitService.GetById(id);

            if (controlUnit == null)
            {
                return NotFound("ControlUnit not found");
            }

            return Ok(controlUnit);
        }

        [HttpPost]
        public async Task<ActionResult<ControlUnit>> Create([FromBody] ControlUnitOnly controlUnitOnly)
        {
            var controlUnit = await _controlUnitService.Add(controlUnitOnly);
            return CreatedAtAction(nameof(GetById), new { id = controlUnit.Id }, controlUnit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ControlUnitOnly controlUnitOnly)
        {
            await _controlUnitService.Update(id, controlUnitOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var controlUnit = await _controlUnitService.GetById(id);
            if (controlUnit == null)
            {
                return NotFound("ControlUnit not found");
            }
            await _controlUnitService.Delete(id);
            return NoContent();
        }
    }
}
