using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Business.Repositories
{
    public class ControlUnitRepository : IControlUnitRepository
    {
        private readonly ParkingManagementContext _context;

        public ControlUnitRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ControlUnit>> GetAllAsync()
        {
            return await _context.ControlUnits.ToListAsync();
        }

        public async Task<ControlUnit?> GetByIdAsync(int id)
        {
            return await _context.ControlUnits.FindAsync(id);
        }

        public async Task AddAsync(ControlUnit controlUnit)
        {
            _context.ControlUnits.Add(controlUnit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ControlUnit controlUnit)
        {
            _context.ControlUnits.Update(controlUnit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var controlUnit = await _context.ControlUnits.FindAsync(id);
            if (controlUnit != null)
            {
                _context.ControlUnits.Remove(controlUnit);
                await _context.SaveChangesAsync();
            }
        }
    }
}