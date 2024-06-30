using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
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
}