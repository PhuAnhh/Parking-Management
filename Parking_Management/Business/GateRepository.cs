using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interfaces;
using Parking_Management.Dto;

namespace Parking_Management.Business.Repositories
{
    public class GateRepository : IGateRepository
    {
        private readonly ParkingManagementContext _context;

        public GateRepository(ParkingManagementContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Gate>> GetAllAsync()
        {
            return await _context.Gates.ToListAsync();
        }

        public async Task<Gate?> GetByIdAsync(int id)
        {
            return await _context.Gates.FindAsync(id);
        }

        public async Task AddAsync(Gate gate)
        {
            _context.Gates.Add(gate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gate gate)
        {
            _context.Gates.Update(gate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gate = await _context.Gates.FindAsync(id);
            if (gate != null)
            {
                _context.Gates.Remove(gate);
                await _context.SaveChangesAsync();
            } 
        }
    }
}