using Parking_Management.Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface IComputerRepository
    {
        Task<IEnumerable<Computer>> GetAllAsync();
        Task<Computer> GetByIdAsync(int id);
        Task CreateAsync(Computer computer);
        void Update(Computer computer);
        void Delete(Computer computer);
    }
}
