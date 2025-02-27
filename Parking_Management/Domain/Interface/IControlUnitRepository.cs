using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface IControlUnitRepository
    {
        Task<IEnumerable<ControlUnit>> GetAllAsync();
        Task<ControlUnit?> GetByIdAsync(int id);
        Task AddAsync(ControlUnit controlUnit);
        Task UpdateAsync(ControlUnit controlUnit);
        Task DeleteAsync(int id);
    }
}