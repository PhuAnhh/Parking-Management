using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Business.Services
{
    public class GateService : IGateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Gate>> GetAll()
        {
            return await _unitOfWork.GateRepository.GetAllAsync();
        }

        public async Task<Gate?> GetById(int id)
        {
            return await _unitOfWork.GateRepository.GetByIdAsync(id);
        }

        public async Task<Gate> Add(GateOnly gateOnly)
        {
            var gate = new Gate
            {
                Name = gateOnly.Name,
                CreatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.GateRepository.AddAsync(gate);
            await _unitOfWork.CompleteAsync();
            return gate;
        }

        public async Task Update(int id, GateOnly gateOnly)
        {
            var existingGate = await _unitOfWork.GateRepository.GetByIdAsync(id);
            if (existingGate == null) throw new Exception("Gate not found");

            existingGate.Name = gateOnly.Name;
            existingGate.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.GateRepository.UpdateAsync(existingGate);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.GateRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
