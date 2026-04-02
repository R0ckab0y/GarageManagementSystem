using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Domain.Enums;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class ServiceOrderRepository : GenericRepository<ServiceOrder>, IServiceOrderRepository
    {
        public ServiceOrderRepository(AppDbContext context) : base(context) { }

        public async Task<ServiceOrder?> GetByOrderNumberAsync(string orderNumber)
            => await _dbSet.FirstOrDefaultAsync(x => x.OrderNumber == orderNumber);

        public async Task<ServiceOrder?> GetServiceOrderWithDetailsAsync(Guid serviceOrderId)
            => await _dbSet
                .Include(x => x.Vehicle)
                    .ThenInclude(x => x.customer)
                .Include(x => x.AssignedMechanic)
                .Include(x => x.ServiceItems)
                .Include(x => x.Payments)
                .FirstOrDefaultAsync(x => x.Id == serviceOrderId);

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByStatusAsync(VehicleStatus status)
            => await _dbSet
                .Include(x => x.Vehicle)
                .Include(x => x.AssignedMechanic)
                .Where(x => x.Status == status)
                .ToListAsync();

        public async Task<IEnumerable<ServiceOrder>> GetServiceOrdersByMechanicAsync(Guid mechanicId)
            => await _dbSet
                .Include(x => x.Vehicle)
                .Where(x => x.AssignedMechanicId == mechanicId)
                .ToListAsync();

        public async Task<string> GenerateOrderNumberAsync()
        {
            var today = DateTime.UtcNow;
            var prefix = $"GMS-{today:yyyyMMdd}-";
            var count = await _dbSet
                .CountAsync(x => x.OrderNumber.StartsWith(prefix));
            return $"{prefix}{(count + 1):D4}";
        }
    }
}