using GMS.Domain.Entities;
using GMS.Domain.Enums;

namespace GMS.Application.Interfaces.Repositories;

public interface IServiceOrderRepository : IGenericRepository<ServiceOrder>
{
    Task<ServiceOrder?> GetByOrderNumberAsync(string orderNumber);
    Task<ServiceOrder?> GetServiceOrderWithDetailsAsync(Guid serviceOrderId);
    Task<IEnumerable<ServiceOrder>> GetServiceOrdersByStatusAsync(VehicleStatus status);
    Task<IEnumerable<ServiceOrder>> GetServiceOrdersByMechanicAsync(Guid mechanicId);
    Task<string> GenerateOrderNumberAsync();
}
