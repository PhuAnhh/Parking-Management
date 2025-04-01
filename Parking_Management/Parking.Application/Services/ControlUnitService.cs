using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Application.Services
{
    public class ControlUnitService : IControlUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ControlUnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ControlUnitDto>> GetAllAsync()
        {
            var controlUnits = await _unitOfWork.ControlUnits.GetAllAsync();
            var controlUnitDtos = new List<ControlUnitDto>();

            foreach (var controlUnit in controlUnits)
            {
                controlUnitDtos.Add(new ControlUnitDto
                {
                    Id = controlUnit.Id,
                    Name = controlUnit.Name,
                    Username = controlUnit.Username,
                    Password = controlUnit.Password,
                    Type = controlUnit.Type,
                    ConnectionProtocol = controlUnit.ConnectionProtocol,
                    ComputerId = controlUnit.ComputerId,
                    CreatedAt = controlUnit.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return controlUnitDtos;
        }

        public async Task<ControlUnitDto> GetByIdAsync(int id)
        {
            var controlUnit = await _unitOfWork.ControlUnits.GetByIdAsync(id);

            if (controlUnit == null)
                return null;

            return new ControlUnitDto
            {
                Id = controlUnit.Id,
                Name = controlUnit.Name,
                Username = controlUnit.Username,
                Password = controlUnit.Password,
                Type = controlUnit.Type,
                ConnectionProtocol = controlUnit.ConnectionProtocol,
                ComputerId = controlUnit.ComputerId,
                CreatedAt = controlUnit.CreatedAt,
                UpdatedAt = controlUnit.UpdatedAt
            };
        }

        public async Task<ControlUnitDto> CreateAsync(CreateControlUnitDto createControlUnitDto)
        {
            var controlUnit = new ControlUnit
            {
                Name = createControlUnitDto.Name,
                Username = createControlUnitDto.Username,
                Password = createControlUnitDto.Password,
                Type = createControlUnitDto.Type,
                ConnectionProtocol = createControlUnitDto.ConnectionProtocol,
                ComputerId = createControlUnitDto.ComputerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ControlUnits.CreateAsync(controlUnit);
            await _unitOfWork.SaveChangesAsync();

            return new ControlUnitDto
            {
                Id = controlUnit.Id,
                Name = controlUnit.Name,
                Username = controlUnit.Username,
                Password = controlUnit.Password,
                Type = controlUnit.Type,
                ConnectionProtocol = controlUnit.ConnectionProtocol,
                ComputerId = controlUnit.ComputerId,
                CreatedAt = controlUnit.CreatedAt,
                UpdatedAt = controlUnit.UpdatedAt
            };
        }

        public async Task<ControlUnitDto> UpdateAsync(int id, UpdateControlUnitDto updateControlUnitDto)
        {
            var controlUnit = await _unitOfWork.ControlUnits.GetByIdAsync(id);

            if (controlUnit == null)
                return null;

            controlUnit.Name = updateControlUnitDto.Name;
            controlUnit.Username = updateControlUnitDto.Username;
            controlUnit.Password = updateControlUnitDto.Password;
            controlUnit.Type = updateControlUnitDto.Type;
            controlUnit.ConnectionProtocol = updateControlUnitDto.ConnectionProtocol;
            controlUnit.ComputerId = updateControlUnitDto.ComputerId;
            controlUnit.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.ControlUnits.Update(controlUnit);
            await _unitOfWork.SaveChangesAsync();

            return new ControlUnitDto
            {
                Id = controlUnit.Id,
                Name = controlUnit.Name,
                Username = controlUnit.Username,
                Password = controlUnit.Password,
                Type = controlUnit.Type,
                ConnectionProtocol = controlUnit.ConnectionProtocol,
                ComputerId = controlUnit.ComputerId,
                CreatedAt = controlUnit.CreatedAt,
                UpdatedAt = controlUnit.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var controlUnit = await _unitOfWork.ControlUnits.GetByIdAsync(id);

            if (controlUnit == null)
                return false;

            _unitOfWork.ControlUnits.Delete(controlUnit);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
