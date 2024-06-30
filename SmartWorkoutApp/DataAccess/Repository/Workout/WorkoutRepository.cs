
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
}