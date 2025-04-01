using Parking_Management.Parking.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface ILedRepository
    {
        Task<IEnumerable<Led>> GetAllAsync();
        Task<Led> GetByIdAsync(int id);
        Task CreateAsync(Led led);
        void Update(Led led);
        void Delete(Led led);
    }
}
