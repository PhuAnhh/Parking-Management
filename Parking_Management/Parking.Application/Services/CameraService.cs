using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Application.Services
{
    public class CameraService : ICameraService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CameraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CameraDto>> GetAllAsync()
        {
            var cameras = await _unitOfWork.Cameras.GetAllAsync();
            var cameraDtos = new List<CameraDto>();

            foreach (var camera in cameras)
            {
                cameraDtos.Add(new CameraDto
                {
                    Id = camera.Id,
                    Name = camera.Name,
                    IpAddress = camera.IpAddress,
                    Resolution = camera.Resolution,
                    Type = camera.Type,
                    Username = camera.Username,
                    Password = camera.Password,
                    ComputerId = camera.ComputerId,
                    CreatedAt = camera.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return cameraDtos;
        }

        public async Task<CameraDto> GetByIdAsync(int id)
        {
            var camera = await _unitOfWork.Cameras.GetByIdAsync(id);

            if (camera == null)
                return null;

            return new CameraDto
            {
                Id = camera.Id,
                Name = camera.Name,
                IpAddress = camera.IpAddress,
                Resolution = camera.Resolution,
                Type = camera.Type,
                Username = camera.Username,
                Password = camera.Password,
                ComputerId = camera.ComputerId,
                CreatedAt = camera.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<CameraDto> CreateAsync(CreateCameraDto createCameraDto)
        {
            var camera = new Camera
            {
                Name = createCameraDto.Name,
                IpAddress = createCameraDto.IpAddress,
                Resolution = createCameraDto.Resolution,
                Type = createCameraDto.Type,
                Username = createCameraDto.Username,
                Password = createCameraDto.Password,
                ComputerId = createCameraDto.ComputerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Cameras.CreateAsync(camera);
            await _unitOfWork.SaveChangesAsync();

            return new CameraDto
            {
                Id = camera.Id,
                Name = camera.Name,
                IpAddress = camera.IpAddress,
                Resolution = camera.Resolution,
                Type = camera.Type,
                Username = camera.Username,
                Password = camera.Password,
                ComputerId = camera.ComputerId,
                CreatedAt = camera.CreatedAt,
                UpdatedAt = camera.UpdatedAt
            };
        }

        public async Task<CameraDto> UpdateAsync(int id, UpdateCameraDto updateCameraDto)
        {
            var camera = await _unitOfWork.Cameras.GetByIdAsync(id);

            if (camera == null)
                return null;

            camera.Name = updateCameraDto.Name;
            camera.IpAddress = updateCameraDto.IpAddress;
            camera.Resolution = updateCameraDto.Resolution;
            camera.Type = updateCameraDto.Type;
            camera.Username = updateCameraDto.Username;
            camera.Password = updateCameraDto.Password;
            camera.ComputerId = updateCameraDto.ComputerId;
            camera.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Cameras.Update(camera);
            await _unitOfWork.SaveChangesAsync();

            return new CameraDto
            {
                Id = camera.Id,
                Name = camera.Name,
                IpAddress = camera.IpAddress,
                Resolution = camera.Resolution,
                Type = camera.Type,
                Username = camera.Username,
                Password = camera.Password,
                ComputerId = camera.ComputerId,
                CreatedAt = camera.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var camera = await _unitOfWork.Cameras.GetByIdAsync(id);

            if (camera == null)
                return false;

            _unitOfWork.Cameras.Delete(camera);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

