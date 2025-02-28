using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class LaneService : ILaneService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LaneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Lane>> GetAll()
        {
            return await _unitOfWork.LaneRepository.GetAllAsync();
        }

        public async Task<Lane?> GetById(int id)
        {
            return await _unitOfWork.LaneRepository.GetByIdAsync(id);
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
            await _unitOfWork.LaneRepository.AddAsync(lane);
            await _unitOfWork.CompleteAsync();
            return lane;
        }

        public async Task Update(int id, LaneOnly laneOnly)
        {
            var existingLane = await _unitOfWork.LaneRepository.GetByIdAsync(id);
            if (existingLane == null) throw new Exception("Lane not found");

            existingLane.Name = laneOnly.Name;
            existingLane.Type = laneOnly.Type;
            existingLane.ComputerId = laneOnly.ComputerId;
            existingLane.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.LaneRepository.UpdateAsync(existingLane);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.LaneRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
