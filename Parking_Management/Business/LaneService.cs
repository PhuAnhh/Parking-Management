using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class LaneService : ILaneService
    {
        private readonly ILaneRepository _laneRepository;

        public LaneService(ILaneRepository laneRepository)
        {
            _laneRepository = laneRepository;
        }

        public async Task<IEnumerable<Lane>> GetAll()
        {
            return await _laneRepository.GetAllAsync();
        }

        public async Task<Lane?> GetById(int id)
        {
            return await _laneRepository.GetByIdAsync(id);
        }

        public async Task<Lane> Add(LaneOnly laneOnly)
        {
            var lane = new Lane
            {
                Name = laneOnly.Name,
                Type = laneOnly.Type,
                ComputerId = laneOnly.ComputerId,
                CreatedAt = DateTime.UtcNow,
            };
            await _laneRepository.AddAsync(lane);
            return lane;
        }

        public async Task Update(int id, LaneOnly laneOnly)
        {
            var existingLane = await _laneRepository.GetByIdAsync(id);
            if (existingLane == null) throw new Exception("Lane not found");

            existingLane.Name = laneOnly.Name;
            existingLane.Type = laneOnly.Type;
            existingLane.ComputerId = laneOnly.ComputerId;
            existingLane.UpdatedAt = DateTime.UtcNow;

            await _laneRepository.UpdateAsync(existingLane);
        }

        public async Task Delete(int id)
        {
            await _laneRepository.DeleteAsync(id);
        }
    }
}
