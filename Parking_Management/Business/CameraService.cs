using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class CameraService : ICameraService
    {
        private readonly ICameraRepository _cameraRepository;

        public CameraService(ICameraRepository cameraRepository)
        {
            _cameraRepository = cameraRepository;
        }

        public async Task<IEnumerable<Camera>> GetAll()
        {
            return await _cameraRepository.GetAllAsync();
        }

        public async Task<Camera?> GetById(int id)
        {
            return await _cameraRepository.GetByIdAsync(id);
        }

        public async Task<Camera> Add(CameraOnly cameraOnly)
        {
            var camera = new Camera
            {
                Name = cameraOnly.Name,
                IpAddress = cameraOnly.IpAddress,
                Resolution = cameraOnly.Resolution,
                Type = cameraOnly.Type,
                Username = cameraOnly.Username,
                Password = cameraOnly.Password,
                ComputerId = cameraOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };

            await _cameraRepository.AddAsync(camera);
            return camera;
        }

        public async Task Update(int id, CameraOnly cameraOnly)
        {
            var existingCamera = await _cameraRepository.GetByIdAsync(id);
            if (existingCamera == null) throw new Exception("Camera not found");

            existingCamera.Name = cameraOnly.Name;
            existingCamera.IpAddress = cameraOnly.IpAddress;
            existingCamera.Resolution = cameraOnly.Resolution;
            existingCamera.Type = cameraOnly.Type;
            existingCamera.Username = cameraOnly.Username;
            existingCamera.Password = cameraOnly.Password;
            existingCamera.ComputerId = cameraOnly.ComputerId;
            existingCamera.UpdatedAt = DateTime.UtcNow;

            await _cameraRepository.UpdateAsync(existingCamera);
        }

        public async Task Delete(int id)
        {
            await _cameraRepository.DeleteAsync(id);
        }
    }
}
