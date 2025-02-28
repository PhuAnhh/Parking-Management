using Parking_Management.Domain.Interface;
using System.Threading.Tasks;
using Parking_Management.Domain.Entities;
using Parking_Management.Business.Repositories;

namespace Parking_Management.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingManagementContext _context;
        public IGateRepository GateRepository { get; }
        public IComputerRepository ComputerRepository { get; }
        public ICameraRepository CameraRepository { get; }
        public IControlUnitRepository ControlUnitRepository { get; }
        public ILaneRepository LaneRepository { get; }    
        public ILedRepository LedRepository { get; }

        public UnitOfWork(ParkingManagementContext context, IGateRepository gateRepository, IComputerRepository computerRepository, ICameraRepository cameraRepository, IControlUnitRepository controlUnitRepository, ILaneRepository laneRepository, ILedRepository ledRepository)
        {
            _context = context;
            GateRepository = gateRepository;
            ComputerRepository = computerRepository;
            CameraRepository = cameraRepository;
            ControlUnitRepository = controlUnitRepository;
            LaneRepository = laneRepository;
            LedRepository = ledRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
