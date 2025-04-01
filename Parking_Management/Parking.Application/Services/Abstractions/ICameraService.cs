using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Services.Abstractions
{
    public interface ICameraService
    {
        Task<IEnumerable<CameraDto>> GetAllAsync();
        Task<CameraDto> GetByIdAsync(int id);
        Task<CameraDto> CreateAsync(CreateCameraDto createCameraDto);
        Task<CameraDto> UpdateAsync(int id, UpdateCameraDto updateCameraDto);
        Task<bool> DeleteAsync(int id);
    }
}
