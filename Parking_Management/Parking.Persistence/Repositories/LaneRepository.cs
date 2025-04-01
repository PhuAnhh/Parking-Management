using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class LaneRepository : ILaneRepository
    {
        public readonly ParkingManagementContext _context;

        public LaneRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lane>> GetAllAsync()
        {
            return await _context.Lanes.ToListAsync();
        }

        public async Task<Lane> GetByIdAsync(int id)
        {
            return await _context.Lanes.FindAsync(id);
        }

        public async Task CreateAsync(Lane lane)
        {
            await _context.Lanes.AddAsync(lane);
        }

        public void Update(Lane lane)
        {
            _context.Lanes.Update(lane);
        }

        public void Delete(Lane lane)
        {
            _context.Lanes.Remove(lane);
        }
    }
}
