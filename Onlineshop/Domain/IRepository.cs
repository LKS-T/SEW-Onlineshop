using System.Linq.Expressions;

namespace Domain;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> CreateAsync(TEntity t);
    Task<List<TEntity>> CreateRangeAsync(List<TEntity> tList);
    Task UpdateAsync(TEntity t);
    Task UpdateRangeAsync(List<TEntity> tList);
    Task<TEntity?> ReadAsync(int id);
    Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TEntity>> ReadAsync(int start, int count);
    Task<List<TEntity>> ReadAsync();
    Task DeleteAsync(TEntity t);
}