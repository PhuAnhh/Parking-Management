using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interfaces
{
    public interface IGateRepository
    {
        Task<IEnumerable<Gate>> GetAllAsync();
        Task<Gate?> GetByIdAsync(int id);
        Task AddAsync(Gate gate);
        Task UpdateAsync(Gate gate);
        Task DeleteAsync(int id);
    }
}
