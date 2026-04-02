using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Domain.Enums;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context) { }

        public async Task<Employee?> GetByEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<IEnumerable<Employee>> GetByRoleAsync(UserRole role)
            => await _dbSet.Where(x => x.Role == role).ToListAsync();

        public async Task<IEnumerable<Employee>> GetActiveMechanicsAsync()
            => await _dbSet
                .Where(x => x.Role == UserRole.Mechanic && x.IsActive)
                .ToListAsync();
    }
}