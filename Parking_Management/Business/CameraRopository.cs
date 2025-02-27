using Microsoft.EntityFrameworkCore;
using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;

namespace Parking_Management.Business.Repositories
{
    public class CameraRepository : ICameraRepository
    {
        private readonly ParkingManagementContext _context;

        public CameraRepository(ParkingManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Camera>> GetAllAsync()
        {
            return await _context.Cameras.ToListAsync();
        }

        public async Task<Camera?> GetByIdAsync(int id)
        {
            return await _context.Cameras.FindAsync(id);
        }

        public async Task AddAsync(Camera camera)
        {
            _context.Cameras.Add(camera);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Camera camera)
        {
            _context.Cameras.Update(camera);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var camera = await _context.Cameras.FindAsync(id);
            if (camera != null)
            {
                _context.Cameras.Remove(camera);
                await _context.SaveChangesAsync();
            }
        }
    }
}