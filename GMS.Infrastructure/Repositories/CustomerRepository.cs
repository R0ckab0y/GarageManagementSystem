using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context) { }

        public async Task<Customer?> GetByEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

        public Task<Customer?> GetCustomerWithVehicleAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer?> GetCustomerWithVehiclesAsync(Guid customerId)
            => await _dbSet
                .Include(x => x.vehicles)
                .FirstOrDefaultAsync(x => x.Id == customerId);


        public async Task<IEnumerable<Customer>> SearchCustomerAsync(string searchTerm)
            => await _dbSet
                .Where(x => x.FirstName.Contains(searchTerm) ||
                            x.LastName.Contains(searchTerm) ||
                            x.Email.Contains(searchTerm) ||
                            x.Phone.Contains(searchTerm))
                .ToListAsync();
    }
}