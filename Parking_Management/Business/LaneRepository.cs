using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Business.Repositories
{
    public class LaneRepository : ILaneRepository
    {
        private readonly ParkingManagementContext _context;

        public LaneRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lane>> GetAllAsync()
        {
            return await _context.Lanes.ToListAsync();
        }

        public async Task<Lane?> GetByIdAsync(int id)
        {
            return await _context.Lanes.FindAsync(id);
        }

        public async Task AddAsync(Lane lane)
        {
            _context.Lanes.Add(lane);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lane lane)
        {
            _context.Lanes.Update(lane);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lane = await _context.Lanes.FindAsync(id);
            if (lane != null)
            {
                _context.Lanes.Remove(lane);
                await _context.SaveChangesAsync();
            }
        }
    }
}