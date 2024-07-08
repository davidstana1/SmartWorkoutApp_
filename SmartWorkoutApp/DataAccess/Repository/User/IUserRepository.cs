using DataAccess.Entities;

namespace DataAccess.Repository;

public interface IUserRepository : IGenericRepository<User>
{
    Task<List<User>> GetAllUsers();
    Task<User> AddUser(User user);
    void DeleteUser(User user);
}