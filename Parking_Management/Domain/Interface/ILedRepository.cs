using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ILedRepository
    {
        Task<IEnumerable<Led>> GetAllAsync();
        Task<Led?> GetByIdAsync(int id);
        Task AddAsync(Led led);
        Task UpdateAsync(Led led);
        Task DeleteAsync(int id);
    }
}