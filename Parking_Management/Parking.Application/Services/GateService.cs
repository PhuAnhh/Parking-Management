using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Application.Services
{
    public class GateService : IGateService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GateDto>> GetAllAsync()
        {
            var gates = await _unitOfWork.Gates.GetAllAsync();
            var gateDtos = new List<GateDto>();

            foreach (var gate in gates)
            {
                gateDtos.Add(new GateDto
                {
                    Id = gate.Id,
                    Name = gate.Name,
                    CreatedAt = gate.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return gateDtos;
        }

        public async Task<GateDto> GetByIdAsync(int id)
        {
            var gate = await _unitOfWork.Gates.GetByIdAsync(id);

            if (gate == null)
                return null;

            return new GateDto
            {
                Id = gate.Id,
                Name = gate.Name,
                CreatedAt = gate.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<GateDto> CreateAsync(CreateGateDto createGateDto)
        {
            var gate = new Gate
            {
                Name = createGateDto.Name,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Gates.CreateAsync(gate);
            await _unitOfWork.SaveChangesAsync();

            return new GateDto
            {
                Id = gate.Id,
                Name = gate.Name,
                CreatedAt = gate.CreatedAt,
                UpdatedAt = gate.UpdatedAt
            };
        }

        public async Task<GateDto> UpdateAsync(int id, UpdateGateDto updateGateDto)
        {
            var gate = await _unitOfWork.Gates.GetByIdAsync(id);

            if (gate == null)
                return null;

            gate.Name = updateGateDto.Name;
            gate.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Gates.Update(gate);
            await _unitOfWork.SaveChangesAsync();

            return new GateDto
            {
                Id = gate.Id,
                Name = gate.Name,
                CreatedAt = gate.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var gate = await _unitOfWork.Gates.GetByIdAsync(id);

            if (gate == null)
                return false;

            _unitOfWork.Gates.Delete(gate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
