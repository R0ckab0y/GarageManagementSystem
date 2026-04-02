using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context) : base(context) { }

        public async Task<Vehicle?> GetByLicensePlateAsync(string licensePlate)
            => await _dbSet.FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);

        public async Task<Vehicle?> GetVehicleWithServiceOrdersAsync(Guid vehicleId)
            => await _dbSet
                .Include(x => x.serviceOrders)
                .FirstOrDefaultAsync(x => x.Id == vehicleId);

        public async Task<IEnumerable<Vehicle>> GetVehiclesByCustomerIdAsync(Guid customerId)
            => await _dbSet
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
    }
}