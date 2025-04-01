using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Application.Services
{
    public class LaneService : ILaneService
    {
        private readonly IUnitOfWork _unitOfWork;
        public LaneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LaneDto>> GetAllAsync()
        {
            var lanes = await _unitOfWork.Lanes.GetAllAsync();
            var laneDtos = new List<LaneDto>();

            foreach (var lane in lanes)
            {
                laneDtos.Add(new LaneDto
                {
                    Id = lane.Id,
                    Name = lane.Name,
                    Type = lane.Type,
                    ComputerId = lane.ComputerId,
                    CreatedAt = lane.CreatedAt,
                    UpdatedAt = lane.UpdatedAt
                });
            }

            return laneDtos;
        }

        public async Task<LaneDto> GetByIdAsync(int id)
        {
            var lane = await _unitOfWork.Lanes.GetByIdAsync(id);

            if (lane == null)
                return null;

            return new LaneDto
            {
                Id = lane.Id,
                Name = lane.Name,
                Type = lane.Type,
                ComputerId = lane.ComputerId,
                CreatedAt = lane.CreatedAt,
            };
        }

        public async Task<LaneDto> CreateAsync(CreateLaneDto createLaneDto)
        {
            var lane = new Lane
            {
                Name = createLaneDto.Name,
                Type = createLaneDto.Type,
                ComputerId = createLaneDto.ComputerId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Lanes.CreateAsync(lane);
            await _unitOfWork.SaveChangesAsync();

            return new LaneDto
            {
                Id = lane.Id,
                Name = lane.Name,
                Type = lane.Type,
                ComputerId = lane.ComputerId,
                CreatedAt = lane.CreatedAt,
            };
        }

        public async Task<LaneDto> UpdateAsync(int id, UpdateLaneDto updateLaneDto)
        {
            var lane = await _unitOfWork.Lanes.GetByIdAsync(id);

            if (lane == null)
                return null;

            lane.Name = updateLaneDto.Name;
            lane.Type = updateLaneDto.Type;
            lane.ComputerId = updateLaneDto.ComputerId;
            lane.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Lanes.Update(lane);
            await _unitOfWork.SaveChangesAsync();

            return new LaneDto
            {
                Id = lane.Id,
                Name = lane.Name,
                Type = lane.Type,
                ComputerId = lane.ComputerId,
                CreatedAt = lane.CreatedAt,
                UpdatedAt = lane.UpdatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var lane = await _unitOfWork.Lanes.GetByIdAsync(id);

            if (lane == null)
                return false;

            _unitOfWork.Lanes.Delete(lane);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
