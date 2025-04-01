using Parking_Management.Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface IControlUnitRepository
    {
        Task<IEnumerable<ControlUnit>> GetAllAsync();
        Task<ControlUnit> GetByIdAsync(int id);
        Task CreateAsync(ControlUnit controlUnit);
        void Update(ControlUnit controlUnit);
        void Delete(ControlUnit controlUnit);
    }
}
