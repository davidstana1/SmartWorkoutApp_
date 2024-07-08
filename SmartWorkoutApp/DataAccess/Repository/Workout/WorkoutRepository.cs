
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
}