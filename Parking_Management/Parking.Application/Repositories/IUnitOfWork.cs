using Parking_Management.Parking.Domain.Entities;
using Parking_Management.Parking.Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parking_Management.Parking.Application.Repositories
{
    public interface IUnitOfWork
    {
        ICameraRepository Cameras {  get; }
        IComputerRepository Computers { get; }
        IControlUnitRepository ControlUnits { get; }
        IGateRepository Gates { get; }
        ILaneRepository Lanes { get; }
        ILedRepository Leds { get; }
        Task<int> SaveChangesAsync();
    }
}
