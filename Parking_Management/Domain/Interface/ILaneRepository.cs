using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ILaneRepository
    {
        Task<IEnumerable<Lane>> GetAllAsync();
        Task<Lane?> GetByIdAsync(int id);
        Task AddAsync(Lane lane);
        Task UpdateAsync(Lane lane);
        Task DeleteAsync(int id);
    }
}