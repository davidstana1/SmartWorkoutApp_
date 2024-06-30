using System.Linq.Expressions;

namespace DataAccess.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
}