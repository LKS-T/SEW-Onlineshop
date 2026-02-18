using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Domain;

public abstract class ARepository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _table;
    protected ARepository(DbContext context) {
        _context = context;
        _table = context.Set<TEntity>();
    }
    public async Task<TEntity> CreateAsync(TEntity t)
    {
        _context.ChangeTracker.Clear();
        _table.Add(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> tList)
    {
        _table.AddRange(tList);
        await _context.SaveChangesAsync();
        return tList;
    }

    public async Task UpdateAsync(TEntity t)
    {
        _context.ChangeTracker.Clear();
        _table.Update(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> tList)
    {
        _table.UpdateRange(tList);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.Where(filter).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        return await _table.Skip(start).Take(count).ToListAsync();
    }

    public async Task<List<TEntity>> ReadAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        _table.Remove(t);
        await _context.SaveChangesAsync();
    }
}