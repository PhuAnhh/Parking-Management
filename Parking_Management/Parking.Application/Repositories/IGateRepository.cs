using Parking_Management.Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface IGateRepository
    {
        Task<IEnumerable<Gate>> GetAllAsync();
        Task<Gate> GetByIdAsync(int id);
        Task CreateAsync(Gate gate);
        void Update(Gate gate);
        void Delete(Gate gate);
    }
}
