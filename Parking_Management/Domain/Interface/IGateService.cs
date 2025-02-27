using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interfaces
{
    public interface IGateService
    {
        Task<IEnumerable<Gate>> GetAll();
        Task<Gate?> GetById(int id);
        Task<Gate> Add(GateOnly gateOnly);
        Task Update(int id, GateOnly gateOnly);
        Task Delete(int id);
    }
}
