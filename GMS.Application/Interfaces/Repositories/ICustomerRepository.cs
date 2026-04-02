using GMS.Domain.Entities;
namespace GMS.Application.Interfaces.Repositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    Task<Customer?> GetCustomerWithVehicleAsync(Guid customerId);
    Task<IEnumerable<Customer>> SearchCustomerAsync(string searchTerm);
}
