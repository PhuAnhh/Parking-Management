using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Parking_Management.Parking.Application.Services.Abstractions;

namespace Parking_Management.Parking.Application.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ComputerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ComputerDto>> GetAllAsync()
        {
            var computers = await _unitOfWork.Computers.GetAllAsync();
            var computerDtos = new List<ComputerDto>();

            foreach (var computer in computers)
            {
                computerDtos.Add(new ComputerDto
                {
                    Id = computer.Id,
                    Name = computer.Name,
                    IpAddress = computer.IpAddress,
                    GateId = computer.GateId,
                    CreatedAt = computer.CreatedAt,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            return computerDtos;
        }

        public async Task<ComputerDto> GetByIdAsync(int id)
        {
            var computer = await _unitOfWork.Computers.GetByIdAsync(id);

            if (computer == null)
                return null;

            return new ComputerDto
            {
                Id = computer.Id,
                Name = computer.Name,
                IpAddress= computer.IpAddress,
                GateId= computer.GateId,
                CreatedAt = computer.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<ComputerDto> CreateAsync(CreateComputerDto createComputerDto)
        {
            var computer = new Computer
            {
                Name = createComputerDto.Name,
                IpAddress = createComputerDto.IpAddress,
                GateId = createComputerDto.GateId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Computers.CreateAsync(computer);
            await _unitOfWork.SaveChangesAsync();

            return new ComputerDto
            {
                Id = computer.Id,
                Name = computer.Name,
                IpAddress = computer.IpAddress,
                GateId = computer.GateId,
                CreatedAt = computer.CreatedAt,
                UpdatedAt = computer.UpdatedAt
            };
        }

        public async Task<ComputerDto> UpdateAsync(int id, UpdateComputerDto updateComputerDto)
        {
            var computer = await _unitOfWork.Computers.GetByIdAsync(id);

            if (computer == null)
                return null;

            computer.Name = updateComputerDto.Name;
            computer.IpAddress = updateComputerDto.IpAddress;
            computer.GateId = updateComputerDto.GateId;
            computer.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Computers.Update(computer);
            await _unitOfWork.SaveChangesAsync();

            return new ComputerDto
            {
                Id = computer.Id,
                Name = computer.Name,
                IpAddress = computer.IpAddress,
                GateId= computer.GateId,
                CreatedAt = computer.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var computer = await _unitOfWork.Computers.GetByIdAsync(id);

            if (computer == null)
                return false;

            _unitOfWork.Computers.Delete(computer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
