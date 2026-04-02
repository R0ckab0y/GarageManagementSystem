using GMS.Domain.Entities;
namespace GMS.Application.Interfaces.Repositories;

public interface IAppUserRepository : IGenericRepository<AppUser>
{
    Task<AppUser?> GetByUsernameAsync(string username);
    Task<AppUser?> GetByEmailAsync(string email);
    Task<AppUser?> GetByRefreshTokenAsync(string refreshToken);
}
