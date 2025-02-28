using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class LedService : ILedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Led>> GetAll()
        {
            return await _unitOfWork.LedRepository.GetAllAsync();
        }

        public async Task<Led?> GetById(int id)
        {
            return await _unitOfWork.LedRepository.GetByIdAsync(id);
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

            await _unitOfWork.LedRepository.AddAsync(led);
            await _unitOfWork.CompleteAsync();
            return led;
        }

        public async Task Update(int id, LedOnly ledOnly)
        {
            var existingLed = await _unitOfWork.LedRepository.GetByIdAsync(id);
            if (existingLed == null) throw new Exception("Led not found");

            existingLed.Name = ledOnly.Name;
            existingLed.ComputerId = ledOnly.ComputerId;
            existingLed.Type = ledOnly.Type;    
            existingLed.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.LedRepository.UpdateAsync(existingLed);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.LedRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
