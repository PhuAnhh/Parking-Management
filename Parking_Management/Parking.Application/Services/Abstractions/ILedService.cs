using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface ILedService
    {
        Task<IEnumerable<LedDto>> GetAllAsync();
        Task<LedDto> GetByIdAsync(int id);
        Task<LedDto> CreateAsync(CreateLedDto createLedDto);
        Task<LedDto> UpdateAsync(int id, UpdateLedDto updateLedDto);
        Task<bool> DeleteAsync(int id);
    }
}
