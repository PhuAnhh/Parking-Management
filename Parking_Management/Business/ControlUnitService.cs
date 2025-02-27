using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class ControlUnitService : IControlUnitService
    {
        private readonly IControlUnitRepository _controlUnitRepository;

        public ControlUnitService(IControlUnitRepository controlUnitRepository)
        {
            _controlUnitRepository = controlUnitRepository;
        }

        public async Task<IEnumerable<ControlUnit>> GetAll()
        {
            return await _controlUnitRepository.GetAllAsync();
        }

        public async Task<ControlUnit?> GetById(int id)
        {
            return await _controlUnitRepository.GetByIdAsync(id);
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

            await _controlUnitRepository.AddAsync(controlUnit);
            return controlUnit;
        }

        public async Task Update(int id, ControlUnitOnly controlUnitOnly)
        {
            var existingControlUnit = await _controlUnitRepository.GetByIdAsync(id);
            if (existingControlUnit == null) throw new Exception("ControlUnit not found");

            existingControlUnit.Name = controlUnitOnly.Name;
            existingControlUnit.Username = controlUnitOnly.Username;
            existingControlUnit.Password = controlUnitOnly.Password;
            existingControlUnit.Type = controlUnitOnly.Type;
            existingControlUnit.ConnectionProtocol = controlUnitOnly.ConnectionProtocol;
            existingControlUnit.ComputerId = controlUnitOnly.ComputerId;
            existingControlUnit.UpdatedAt = DateTime.UtcNow;

            await _controlUnitRepository.UpdateAsync(existingControlUnit);
        }

        public async Task Delete(int id)
        {
            await _controlUnitRepository.DeleteAsync(id);
        }
    }
}
