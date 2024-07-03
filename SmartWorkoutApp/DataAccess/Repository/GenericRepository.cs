using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
        _dbSet = _appDbContext.Set<T>(); 
    }

    public async Task<List<T>> GetAll()
    {
        return await _appDbContext.Set<T>().ToListAsync();
    }
    
    public async Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = _appDbContext.Set<T>();
            
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }

        return await query.ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }
    
    public async Task Update(T entity)
    {
        _dbSet.Update(entity);
        await _appDbContext.SaveChangesAsync();
    }
}