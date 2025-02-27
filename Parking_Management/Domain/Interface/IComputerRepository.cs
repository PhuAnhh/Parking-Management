using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface IComputerRepository
    {
        Task<IEnumerable<Computer>> GetAllAsync();
        Task<Computer?> GetByIdAsync(int id);
        Task AddAsync(Computer computer);
        Task UpdateAsync(Computer computer);
        Task DeleteAsync(int id);
    }
}