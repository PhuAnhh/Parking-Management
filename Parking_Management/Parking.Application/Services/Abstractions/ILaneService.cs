using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface ILaneService
    {
        Task<IEnumerable<LaneDto>> GetAllAsync();
        Task<LaneDto> GetByIdAsync(int id);
        Task<LaneDto> CreateAsync(CreateLaneDto createLaneDto);
        Task<LaneDto> UpdateAsync(int id, UpdateLaneDto updateLaneDto);
        Task<bool> DeleteAsync(int id);
    }
}
