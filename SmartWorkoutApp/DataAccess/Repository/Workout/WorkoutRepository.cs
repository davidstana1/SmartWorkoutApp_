
using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;

namespace DataAccess.Repository.Workout;

public class WorkoutRepository : GenericRepository<Entities.Workout> , IWorkoutRepository
{
    public WorkoutRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<List<Entities.Workout>> GetAllWorkouts()
    {
        return await GetAllWithInclude(u=>u.User);
    }
    
    public async Task<List<Entities.Workout>> GetALlWithExerciseLogs()
    {
        return await _appDbContext.Workouts
            .Include(w => w.User)
            .Include(w => w.Exercises)
            .ThenInclude(e => e.ExerciseLogs)
            .ToListAsync();
    }

    public async Task<Entities.Workout> AddWorkout(Entities.Workout workout)
    {
        return await Add(workout);
    }
    public async Task DeleteWorkoutsByUserIdAsync(string userId)
    {
        var workouts = await GetAll(w => w.User.Id == userId); // Exemplu de filtrare după UserId

        foreach (var workout in workouts)
        {
            await Delete(workout);
        }
    }
    public async Task<List<Entities.Workout>> GetAllForTrainer(string trainerId)
    {
        return await _appDbContext.Workouts
            .Include(w => w.User)
            .Include(w => w.User.Trainer)
            .Include(w => w.Exercises)
            .ThenInclude(e => e.ExerciseLogs)
            .Where(w => w.User.Trainer.Id == trainerId)
            .ToListAsync();
    }
    
    public async Task<List<Entities.Workout>> GetAllForUser(string userId)
    {
        return await _appDbContext.Workouts
            .Include(w => w.User)
            .Include(w=>w.Exercises)
            .ThenInclude(e => e.ExerciseLogs)// Include pentru a aduce detalii despre utilizator
            .Where(w => w.User.Id == userId)
            .ToListAsync();
    }
}