namespace DataAccess.Repository.Workout;

public interface IWorkoutRepository : IGenericRepository<Entities.Workout>
{
    Task<List<Entities.Workout>> GetAllWorkouts();

    Task<List<Entities.Workout>> GetALlWithExerciseLogs();
    Task<Entities.Workout> AddWorkout(Entities.Workout workout);
    Task DeleteWorkoutsByUserIdAsync(string userId);
    Task<List<Entities.Workout>> GetAllForTrainer(string trainerId);
    Task<List<Entities.Workout>> GetAllForUser(string userId);
}