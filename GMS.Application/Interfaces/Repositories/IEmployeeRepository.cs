using GMS.Domain.Entities;
using GMS.Domain.Enums;

namespace GMS.Application.Interfaces.Repositories;

public interface IEmployeeRepository : IGenericRepository<Employee>
{
    Task<Employee?> GetByEmailAsync(string email);
    Task<IEnumerable<Employee>> GetByRoleAsync(UserRole role);
    Task<IEnumerable<Employee>> GetActiveMechanicsAsync();
}
