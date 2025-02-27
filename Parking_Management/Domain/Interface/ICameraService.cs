using Parking_Management.Dto;
using Parking_Management.Domain.Entities;

namespace Parking_Management.Domain.Interface
{
    public interface ICameraService
    {
        Task<IEnumerable<Camera>> GetAll();
        Task<Camera?> GetById(int id);
        Task<Camera> Add(CameraOnly cameraOnly);
        Task Update(int id, CameraOnly cameraOnly);
        Task Delete(int id);
    }
} 
