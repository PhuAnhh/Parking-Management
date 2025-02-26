using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parking_Management.Dto;
using Parking_Management.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

[Route("api/[controller]")]
[ApiController]
public class ComputerController : ControllerBase
{
    private readonly ParkingManagementContext _context;

    public ComputerController(ParkingManagementContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Computer>>> GetComputers()
    {
        return await _context.Computers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Computer>> GetComputer(int id)
    {
        var computer = await _context.Computers.FirstOrDefaultAsync(i => i.Id == id);
        if (computer == null)
        {
            return NotFound();
        }
        return computer;
    }

    [HttpPost]
    public async Task<ActionResult<Computer>> PostComputer(ComputerOnly computerOnly)
    {
        var computer = new Computer
        {
            Name = computerOnly.Name,
            IpAddress = computerOnly.IpAddress,
            GateId = computerOnly.GateId,
            CreatedAt = DateTime.UtcNow,
        };

        _context.Computers.Add(computer);
        await _context.SaveChangesAsync();

        return Ok(computer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutComputer(int id, ComputerOnly computer)
    {
        if (id != computer.Id)
        {
            return BadRequest("ID not found");
        }
        var existingComputer = await _context.Computers.FirstOrDefaultAsync(i => i.Id == id);
        if (existingComputer == null)
        {
            return NotFound("Computer not found");
        }

        existingComputer.Name = computer.Name;
        existingComputer.IpAddress = computer.IpAddress;
        existingComputer.GateId = computer.GateId;
        existingComputer.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComputer(int id)
    {
        var computer = await _context.Computers.FirstOrDefaultAsync(i => i.Id == id);
        if (computer == null)
        {
            return NotFound();
        }
        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
