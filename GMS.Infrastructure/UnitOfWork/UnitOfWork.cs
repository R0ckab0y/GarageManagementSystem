using GMS.Application.Interfaces;
using GMS.Application.Interfaces.Repositories;
using GMS.Infrastructure.Data;
using GMS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace GMS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public ICustomerRepository Customers { get; }
        public IVehicleRepository Vehicles { get; }
        public IServiceOrderRepository ServiceOrders { get; }
        public IEmployeeRepository Employees { get; }
        public IPaymentRepository Payments { get; }
        public IAppUserRepository AppUsers { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Customers = new CustomerRepository(context);
            Vehicles = new VehicleRepository(context);
            ServiceOrders = new ServiceOrderRepository(context);
            Employees = new EmployeeRepository(context);
            Payments = new PaymentRepository(context);
            AppUsers = new AppUserRepository(context);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public async Task BeginTransactionAsync()
            => _transaction = await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}