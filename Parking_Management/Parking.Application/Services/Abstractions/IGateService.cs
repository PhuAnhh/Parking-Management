using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface IGateService
    {
        Task<IEnumerable<GateDto>> GetAllAsync();
        Task<GateDto> GetByIdAsync(int id);
        Task<GateDto> CreateAsync(CreateGateDto createGateDto);
        Task<GateDto> UpdateAsync(int id, UpdateGateDto updateGateDto);
        Task<bool> DeleteAsync(int id);
    }
}
