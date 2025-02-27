using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface IComputerService
    {
        Task<IEnumerable<Computer>> GetAll();
        Task<Computer?> GetById(int id);
        Task<Computer> Add(ComputerOnly computerOnly);
        Task Update(int id, ComputerOnly computerOnly);
        Task Delete(int id);
    }
}
