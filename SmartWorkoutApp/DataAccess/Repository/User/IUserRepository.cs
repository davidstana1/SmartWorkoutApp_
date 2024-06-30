using DataAccess.Entities;

namespace DataAccess.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<List<User>> GetAll();
}