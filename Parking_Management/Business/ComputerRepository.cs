using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Business.Repositories
{
    public class ComputerRepository : IComputerRepository
    {
        private readonly ParkingManagementContext _context;

        public ComputerRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Computer>> GetAllAsync()
        {
            return await _context.Computers.ToListAsync();
        }

        public async Task<Computer?> GetByIdAsync(int id)
        {
            return await _context.Computers.FindAsync(id);
        }

        public async Task AddAsync(Computer computer)
        {
            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Computer computer)
        {
            _context.Computers.Update(computer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer != null)
            {
                _context.Computers.Remove(computer);
                await _context.SaveChangesAsync();
            }
        }
    }
}