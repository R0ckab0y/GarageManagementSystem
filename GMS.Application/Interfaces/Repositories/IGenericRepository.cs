using System;
using System.Linq.Expressions;
using GMS.Domain.Common;

namespace GMS.Application.Interfaces.Repositories;

public interface IGenericRepository<T> where T : BaseEntity
{
    //Query
    Task<T?> GetByIdAsync(Guid Id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    Task<T?> FindSingleAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    //Iqueryable
    IQueryable<T> GetQueryable();

    //Command
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entities);
    void SoftDelete(T entity, string deletedBy);
}
