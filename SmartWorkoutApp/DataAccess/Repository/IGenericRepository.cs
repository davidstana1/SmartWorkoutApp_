using System.Linq.Expressions;
using DataAccess.Entities;

namespace DataAccess.Repository;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
    Task<List<T>> GetAllWithInclude(params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetById(string id);
    Task<T> GetBy(Expression<Func<T, bool>> predicate);
    Task<T> Add(T entity);
    Task Delete(T entity);
    Task Update(T entity);
    Task<User> GetByEmail(string email);
    Task<Trainer> GetByEmailTrainer(string email);
}