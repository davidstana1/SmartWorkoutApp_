using DataAccess.Entities;
using DataAccess.Entities.BaseEntity;

namespace DataAccess.Repository.Exercises;

public interface IExerciseRepository : IGenericRepository<Exercise>
{
    Task<List<Exercise>> GetAllExercises();
}