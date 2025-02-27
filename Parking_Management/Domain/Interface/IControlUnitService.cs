using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface IControlUnitService
    {
        Task<IEnumerable<ControlUnit>> GetAll();
        Task<ControlUnit?> GetById(int id);
        Task<ControlUnit> Add(ControlUnitOnly controlUnitOnly);
        Task Update(int id, ControlUnitOnly controlUnitOnly);
        Task Delete(int id);
    }

}
