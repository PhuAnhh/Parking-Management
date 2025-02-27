using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Business.Repositories
{
    public class LedRepository : ILedRepository
    {
        private readonly ParkingManagementContext _context;

        public LedRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Led>> GetAllAsync()
        {
            return await _context.Leds.ToListAsync();
        }

        public async Task<Led?> GetByIdAsync(int id)
        {
            return await _context.Leds.FindAsync(id);
        }

        public async Task AddAsync(Led led)
        {
            _context.Leds.Add(led);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Led led)
        {
            _context.Leds.Update(led);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var led = await _context.Leds.FindAsync(id);
            if (led != null)
            {
                _context.Leds.Remove(led);
                await _context.SaveChangesAsync();
            }
        }
    }
}