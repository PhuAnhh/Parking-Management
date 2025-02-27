using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ICameraRepository
    {
        Task<IEnumerable<Camera>> GetAllAsync();
        Task<Camera?> GetByIdAsync(int id);
        Task AddAsync(Camera camera);
        Task UpdateAsync(Camera camera);
        Task DeleteAsync(int id);
    }
}
