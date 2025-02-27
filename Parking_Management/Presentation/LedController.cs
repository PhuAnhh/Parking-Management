using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Domain.Entities;
using System.Linq;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly ILedService _ledService;

        public LedController(ILedService ledService)
        {
            _ledService = ledService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Led>>> GetAll()
        {
            return Ok(await _ledService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Led>> GetById(int id)
        {
            var led = await _ledService.GetById(id);

            if (led == null)
            {
                return NotFound("Led not found");
            }

            return Ok(led);
        }

        [HttpPost]
        public async Task<ActionResult<Led>> CreateGate([FromBody] LedOnly ledOnly)
        {
            var led = await _ledService.Add(ledOnly);
            return CreatedAtAction(nameof(GetById), new { id = led.Id }, led);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LedOnly ledOnly)
        {
            await _ledService.Update(id, ledOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var led = await _ledService.GetById(id);
            if (led == null)
            {
                return NotFound("Led not found");
            }
            await _ledService.Delete(id);
            return NoContent();
        }
    }
}
