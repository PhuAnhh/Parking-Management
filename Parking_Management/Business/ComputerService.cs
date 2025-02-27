using Parking_Management.Domain.Entities;
using Parking_Management.Domain.Interface;
using Parking_Management.Dto;

namespace Parking_Management.Business.Services
{
    public class ComputerService : IComputerService
    {
        private readonly IComputerRepository _computerRepository;

        public ComputerService(IComputerRepository computerRepository)
        {
            _computerRepository = computerRepository;
        }

        public async Task<IEnumerable<Computer>> GetAll()
        {
            return await _computerRepository.GetAllAsync();
        }

        public async Task<Computer?> GetById(int id)
        {
            return await _computerRepository.GetByIdAsync(id);
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

            await _computerRepository.AddAsync(computer);
            return computer;
        }

        public async Task Update(int id, ComputerOnly computerOnly)
        {
            var existingComputer = await _computerRepository.GetByIdAsync(id);
            if (existingComputer == null) throw new Exception("Computer not found");

            existingComputer.Name = computerOnly.Name;
            existingComputer.IpAddress = computerOnly.IpAddress;
            existingComputer.GateId = computerOnly.GateId;
            existingComputer.UpdatedAt = DateTime.UtcNow;

            await _computerRepository.UpdateAsync(existingComputer);
        }

        public async Task Delete(int id)
        {
            await _computerRepository.DeleteAsync(id);
        }
    }
}
