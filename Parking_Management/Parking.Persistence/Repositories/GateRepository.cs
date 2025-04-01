using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class GateRepository : IGateRepository
    {
        public readonly ParkingManagementContext _context;

        public GateRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gate>> GetAllAsync()
        {
            return await _context.Gates.AsNoTracking().ToListAsync();
        }

        public async Task<Gate> GetByIdAsync(int id)
        {
            return await _context.Gates.FindAsync(id);
        }

        public async Task CreateAsync(Gate gate)
        {
            await _context.Gates.AddAsync(gate);
        }

        public void Update(Gate gate)
        {
            _context.Gates.Update(gate);
        }

        public void Delete(Gate gate)
        {
            _context.Gates.Remove(gate);
        }
    }
}
