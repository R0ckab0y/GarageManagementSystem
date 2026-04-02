using GMS.Application.Interfaces.Repositories;
using GMS.Domain.Entities;
using GMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GMS.Infrastructure.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context) { }

        public async Task<AppUser?> GetByUsernameAsync(string username)
            => await _dbSet.FirstOrDefaultAsync(x => x.Username == username);

        public async Task<AppUser?> GetByEmailAsync(string email)
            => await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<AppUser?> GetByRefreshTokenAsync(string refreshToken)
            => await _dbSet.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
    }
}