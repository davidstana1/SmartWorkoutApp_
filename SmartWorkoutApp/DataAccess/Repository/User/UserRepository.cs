using DataAccess.Entities;
using DataAccess.Repository.Workout;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DataAccess.Repository.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly IWorkoutRepository _workoutRepository;

    public UserRepository(AppDbContext appDbContext, IWorkoutRepository workoutRepository) : base(appDbContext)
    {
        _workoutRepository = workoutRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await GetAll();
    }

    public async Task<User> AddUser(User user)
    {
        return await Add(user);
    }

    public void DeleteUser(User user)
    {
        foreach (var workout in user.Workouts)
        {
            foreach (var exercise in workout.Exercises.ToList())
            {
                _appDbContext.ExerciseLogs.RemoveRange(exercise.ExerciseLogs);
                _appDbContext.Exercises.Remove(exercise); // Șterge exercițiile asociate antrenamentului
            }
            _appDbContext.Workouts.Remove(workout); // Șterge antrenamentul
        }
        _appDbContext.Users.Remove(user); // Șterge utilizatorul
    
        _appDbContext.SaveChanges();
    }

    public async Task<List<User>> GetAllUsersForTrainer(string trainerId)
    {
        return await _appDbContext.Users
            .Where(u => u.Trainer.Id == trainerId)
            .ToListAsync();
    }

}