using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        public readonly ParkingManagementContext _context;

        public ComputerRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Computer>> GetAllAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<Computer> GetByIdAsync(int id)
        {
            return await _context.Computers.FindAsync(id);
        }

        public async Task CreateAsync(Computer computer)
        {
            await _context.Computers.AddAsync(computer);
        }

        public void Update(Computer computer)
        {
            _context.Computers.Update(computer);
        }

        public void Delete(Computer computer)
        {
            _context.Computers.Remove(computer);
        }
    }
}
