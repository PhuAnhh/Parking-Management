using Parking_Management.Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface ILaneRepository
    {
        Task<IEnumerable<Lane>> GetAllAsync();
        Task<Lane> GetByIdAsync(int id);
        Task CreateAsync(Lane lane);
        void Update(Lane lane);
        void Delete(Lane lane);
    }
}
