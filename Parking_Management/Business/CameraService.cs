using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class CameraService : ICameraService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CameraService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Camera>> GetAll()
        {
            return await _unitOfWork.CameraRepository.GetAllAsync();
        }

        public async Task<Camera?> GetById(int id)
        {
            return await _unitOfWork.CameraRepository.GetByIdAsync(id);
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

            await _unitOfWork.CameraRepository.AddAsync(camera);
            await _unitOfWork.CompleteAsync();
            return camera;
        }

        public async Task Update(int id, CameraOnly cameraOnly)
        {
            var existingCamera = await _unitOfWork.CameraRepository.GetByIdAsync(id);
            if (existingCamera == null) throw new Exception("Camera not found");

            existingCamera.Name = cameraOnly.Name;
            existingCamera.IpAddress = cameraOnly.IpAddress;
            existingCamera.Resolution = cameraOnly.Resolution;
            existingCamera.Type = cameraOnly.Type;
            existingCamera.Username = cameraOnly.Username;
            existingCamera.Password = cameraOnly.Password;
            existingCamera.ComputerId = cameraOnly.ComputerId;
            existingCamera.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CameraRepository.UpdateAsync(existingCamera);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CameraRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
