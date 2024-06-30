namespace DataAccess.Repository.Workout;

public interface IWorkoutRepository : IGenericRepository<Entities.Workout>
{
    Task<List<Entities.Workout>> GetAllWorkouts();
}