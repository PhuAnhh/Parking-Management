using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface IComputerService
    {
        Task<IEnumerable<ComputerDto>> GetAllAsync();
        Task<ComputerDto> GetByIdAsync(int id);
        Task<ComputerDto> CreateAsync(CreateComputerDto createComputerDto);
        Task<ComputerDto> UpdateAsync(int id, UpdateComputerDto updateComputerDto);
        Task<bool> DeleteAsync(int id);
    }
}
