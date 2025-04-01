using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Parking_Management.Parking.Persistence.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        public readonly ParkingManagementContext _context;

        public CameraRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await _context.Cameras.ToListAsync();
        }

        public async Task<Camera> GetByIdAsync(int id)
        {
            return await _context.Cameras.FindAsync(id);
        }

        public async Task CreateAsync(Camera camera)
        {
            await _context.Cameras.AddAsync(camera);
        }

        public void Update(Camera camera)
        {
            _context.Cameras.Update(camera);
        }

        public void Delete(Camera camera)
        {
            _context.Cameras.Remove(camera);
        }
    }
}
