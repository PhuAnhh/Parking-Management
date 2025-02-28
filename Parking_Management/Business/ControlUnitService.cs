using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class ControlUnitService : IControlUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControlUnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ControlUnit>> GetAll()
        {
            return await _unitOfWork.ControlUnitRepository.GetAllAsync();
        }

        public async Task<ControlUnit?> GetById(int id)
        {
            return await _unitOfWork.ControlUnitRepository.GetByIdAsync(id);
        }

        public async Task<ControlUnit> Add(ControlUnitOnly controlUnitOnly)
        {
            var controlUnit = new ControlUnit
            {
                Name = controlUnitOnly.Name,
                Username = controlUnitOnly.Username,
                Password = controlUnitOnly.Password,
                Type = controlUnitOnly.Type,
                ConnectionProtocol = controlUnitOnly.ConnectionProtocol,
                ComputerId = controlUnitOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.ControlUnitRepository.AddAsync(controlUnit);
            await _unitOfWork.CompleteAsync();
            return controlUnit;
        }

        public async Task Update(int id, ControlUnitOnly controlUnitOnly)
        {
            var existingControlUnit = await _unitOfWork.ControlUnitRepository.GetByIdAsync(id);
            if (existingControlUnit == null) throw new Exception("ControlUnit not found");

            existingControlUnit.Name = controlUnitOnly.Name;
            existingControlUnit.Username = controlUnitOnly.Username;
            existingControlUnit.Password = controlUnitOnly.Password;
            existingControlUnit.Type = controlUnitOnly.Type;
            existingControlUnit.ConnectionProtocol = controlUnitOnly.ConnectionProtocol;
            existingControlUnit.ComputerId = controlUnitOnly.ComputerId;
            existingControlUnit.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ControlUnitRepository.UpdateAsync(existingControlUnit);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.ControlUnitRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
