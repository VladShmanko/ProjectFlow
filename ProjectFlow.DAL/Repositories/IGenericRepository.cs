using System.Linq.Expressions;

namespace ProjectFlow.DAL.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(object id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}