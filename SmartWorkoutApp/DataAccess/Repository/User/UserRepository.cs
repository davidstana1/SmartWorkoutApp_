using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataAccess.Repository.Users;

public class UserRepository : GenericRepository<User> , IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await GetAll();
    }

    public async Task<User> AddUser(User user)
    {
        return await Add(user);
    }
}