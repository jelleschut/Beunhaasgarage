using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository Brands { get; }
        ICarRepository Cars { get; }
        IOwnerRepository Owners { get; }
        IMaintenanceSpecificationRepository MaintenanceSpecifications { get; }
        IModelRepository Models { get; }

        int Complete();
        Task<int> CompleteAsync();

    }
}
