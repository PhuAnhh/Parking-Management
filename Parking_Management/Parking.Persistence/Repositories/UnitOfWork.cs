using Microsoft.EntityFrameworkCore;
using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Application.Repositories;
using Parking_Management.Parking.Persistence.DbContexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ParkingManagementContext _context;
        private ICameraRepository _cameraRepository;
        private IComputerRepository _computerRepository;
        private IControlUnitRepository _controlUnitRepository;
        private IGateRepository _gateRepository;
        private ILaneRepository _laneRepository;
        private ILedRepository _ledRepository;

        public UnitOfWork(ParkingManagementContext context)
        {
            _context = context;
        }

        public ICameraRepository Cameras => _cameraRepository ??= new CameraRepository(_context);
        public IComputerRepository Computers => _computerRepository ??= new ComputerRepository(_context);
        public IControlUnitRepository ControlUnits => _controlUnitRepository ??= new ControlUnitRepository(_context);
        public IGateRepository Gates => _gateRepository ??= new GateRepository(_context);
        public ILaneRepository Lanes => _laneRepository ??= new LaneRepository(_context);
        public ILedRepository Leds => _ledRepository ??= new LedRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
