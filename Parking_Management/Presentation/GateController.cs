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
    public class GateController : ControllerBase
    {
        private readonly IGateService _gateService;

        public GateController(IGateService gateService)
        {
            _gateService = gateService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gate>>> GetAll()
        {
            return Ok(await _gateService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gate>> GetById(int id)
        {
            var gate = await _gateService.GetById(id);

            if (gate == null)
            {
                return NotFound("Gate not found");
            }

            return Ok(gate);
        }

        [HttpPost]
        public async Task<ActionResult<Gate>> Create([FromBody] GateOnly gateOnly)
        {
            var gate = await _gateService.Add(gateOnly);
            return CreatedAtAction(nameof(GetById), new { id = gate.Id }, gate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGate(int id, [FromBody] GateOnly gateOnly)
        {
            await _gateService.Update(id, gateOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gate = await _gateService.GetById(id);
            if(gate == null)
            {
                return NotFound("Gate not found");
            }    
            await _gateService.Delete(id);
            return NoContent();
        }
    }
}
