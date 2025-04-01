using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class ControlUnitRepository : IControlUnitRepository
    {
        public readonly ParkingManagementContext _context;

        public ControlUnitRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ControlUnit>> GetAllAsync()
        {
            return await _context.ControlUnits.ToListAsync();
        }

        public async Task<ControlUnit> GetByIdAsync(int id)
        {
            return await _context.ControlUnits.FindAsync(id);
        }

        public async Task CreateAsync(ControlUnit controlUnit)
        {
            await _context.ControlUnits.AddAsync(controlUnit);
        }

        public void Update(ControlUnit controlUnit)
        {
            _context.ControlUnits.Update(controlUnit);
        }

        public void Delete(ControlUnit controlUnit)
        {
            _context.ControlUnits.Remove(controlUnit);
        }
    }
}
