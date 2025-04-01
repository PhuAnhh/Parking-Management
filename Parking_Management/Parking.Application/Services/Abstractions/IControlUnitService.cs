using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface IControlUnitService
    {
        Task<IEnumerable<ControlUnitDto>> GetAllAsync();
        Task<ControlUnitDto> GetByIdAsync(int id);
        Task<ControlUnitDto> CreateAsync(CreateControlUnitDto createControlUnitDto);
        Task<ControlUnitDto> UpdateAsync(int id, UpdateControlUnitDto updateControlUnitDto);
        Task<bool> DeleteAsync(int id);
    }
}
