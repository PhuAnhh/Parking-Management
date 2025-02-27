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
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetAll()
        {
            return Ok(await _computerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetById(int id)
        {
            var computer = await _computerService.GetById(id);
            if (computer == null)
            {
                return NotFound("Computer not found");
            }
            return Ok(computer);
        }

        [HttpPost]
        public async Task<ActionResult<Computer>> Create(ComputerOnly computerOnly)
        {
            var computer = _computerService.Add(computerOnly);
            return CreatedAtAction(nameof(GetById), new {id = computer.Id}, computer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] ComputerOnly computerOnly)
        {
            await _computerService.Update(id, computerOnly);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var computer = await _computerService.GetById(id);
            if (computer == null)
            {
                return NotFound("Computer not found");
            }
            await _computerService.Delete(id);
            return NoContent();
        }
    }
}