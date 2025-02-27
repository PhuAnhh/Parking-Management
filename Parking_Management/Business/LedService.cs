using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class LedService : ILedService
    {
        private readonly ILedRepository _ledRepository;

        public LedService(ILedRepository ledRepository)
        {
            _ledRepository = ledRepository;
        }

        public async Task<IEnumerable<Led>> GetAll()
        {
            return await _ledRepository.GetAllAsync();
        }

        public async Task<Led?> GetById(int id)
        {
            return await _ledRepository.GetByIdAsync(id);
        }

        public async Task<Led> Add(LedOnly ledOnly)
        {
            var led = new Led
            {
                Name = ledOnly.Name,
                ComputerId = ledOnly.ComputerId,  
                Type = ledOnly.Type,
                CreatedAt = DateTime.UtcNow,
            };

            await _ledRepository.AddAsync(led);
            return led;
        }

        public async Task Update(int id, LedOnly ledOnly)
        {
            var existingLed = await _ledRepository.GetByIdAsync(id);
            if (existingLed == null) throw new Exception("Led not found");

            existingLed.Name = ledOnly.Name;
            existingLed.ComputerId = ledOnly.ComputerId;
            existingLed.Type = ledOnly.Type;    
            existingLed.UpdatedAt = DateTime.UtcNow;

            await _ledRepository.UpdateAsync(existingLed);
        }

        public async Task Delete(int id)
        {
            await _ledRepository.DeleteAsync(id);
        }
    }
}
