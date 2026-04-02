using GMS.Application.Interfaces.Repositories;

namespace GMS.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICustomerRepository Customers { get; }
    IVehicleRepository Vehicles { get; }
    IServiceOrderRepository ServiceOrders { get; }
    IEmployeeRepository Employees { get; }
    IPaymentRepository Payments { get; }
    IAppUserRepository AppUsers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
