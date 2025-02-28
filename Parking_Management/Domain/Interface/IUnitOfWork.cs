using System;
using System.Threading.Tasks;

namespace Parking_Management.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGateRepository GateRepository { get; }
        IComputerRepository ComputerRepository { get; }
        ICameraRepository CameraRepository { get; }
        IControlUnitRepository ControlUnitRepository { get; }
        ILaneRepository LaneRepository { get; }
        ILedRepository LedRepository { get; }
        Task<int> CompleteAsync();
    }
}
