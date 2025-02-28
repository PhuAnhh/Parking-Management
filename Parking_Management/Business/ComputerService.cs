using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComputerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Computer>> GetAll()
        {
            return await _unitOfWork.ComputerRepository.GetAllAsync();
        }

        public async Task<Computer?> GetById(int id)
        {
            return await _unitOfWork.ComputerRepository.GetByIdAsync(id);
        }

        public async Task<Computer> Add(ComputerOnly computerOnly)
        {
            var computer = new Computer
            {
                Name = computerOnly.Name,
                IpAddress = computerOnly.IpAddress,
                GateId = computerOnly.GateId,
                CreatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.ComputerRepository.AddAsync(computer);
            await _unitOfWork.CompleteAsync();
            return computer;
        }

        public async Task Update(int id, ComputerOnly computerOnly)
        {
            var existingComputer = await _unitOfWork.ComputerRepository.GetByIdAsync(id);
            if (existingComputer == null) throw new Exception("Computer not found");

            existingComputer.Name = computerOnly.Name;
            existingComputer.IpAddress = computerOnly.IpAddress;
            existingComputer.GateId = computerOnly.GateId;
            existingComputer.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.ComputerRepository.UpdateAsync(existingComputer);
            await _unitOfWork.CompleteAsync();
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.ComputerRepository.DeleteAsync(id);   
            await _unitOfWork.CompleteAsync();
        }
    }
}
