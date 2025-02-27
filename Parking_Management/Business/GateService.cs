using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interfaces;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class GateService : IGateService
    {
        private readonly IGateRepository _gateRepository;

        public GateService(IGateRepository gateRepository)
        {
            _gateRepository = gateRepository;
        }

        public async Task<IEnumerable<Gate>> GetAll()
        {
            return await _gateRepository.GetAllAsync();
        }

        public async Task<Gate?> GetById(int id)
        {
            return await _gateRepository.GetByIdAsync(id);
        }

        public async Task<Gate> Add(GateOnly gateOnly)
        {
            var gate = new Gate
            {
                Name = gateOnly.Name,
                CreatedAt = DateTime.UtcNow,
            };
            await _gateRepository.AddAsync(gate);
            return gate;
        }

        public async Task Update(int id, GateOnly gateOnly)
        {
            var existingGate = await _gateRepository.GetByIdAsync(id);
            if (existingGate == null) throw new Exception("Gate not found");

            existingGate.Name = gateOnly.Name;
            existingGate.UpdatedAt = DateTime.UtcNow;

            await _gateRepository.UpdateAsync(existingGate);
        }

        public async Task Delete(int id)
        {
            await _gateRepository.DeleteAsync(id);
        }
    }
}
