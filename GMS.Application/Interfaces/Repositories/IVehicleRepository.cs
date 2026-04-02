using GMS.Domain.Entities;
namespace GMS.Application.Interfaces.Repositories;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    Task<Vehicle?> GetByLicensePlateAsync(string licensePlate);
    Task<Vehicle?> GetVehicleWithServiceOrdersAsync(Guid vehicleId);
    Task<IEnumerable<Vehicle>> GetVehiclesByCustomerIdAsync(Guid customerId);
}
