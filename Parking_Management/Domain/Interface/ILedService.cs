using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ILedService
    {
        Task<IEnumerable<Led>> GetAll();
        Task<Led?> GetById(int id);
        Task<Led> Add(LedOnly ledOnly);
        Task Update(int id, LedOnly ledOnly);
        Task Delete(int id);
    }
}
