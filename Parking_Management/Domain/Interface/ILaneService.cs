using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ILaneService
    {
        Task<IEnumerable<Lane>> GetAll();
        Task<Lane?> GetById(int id);
        Task<Lane> Add(LaneOnly laneOnly);
        Task Update(int id, LaneOnly laneOnly);
        Task Delete(int id);
    }

}
