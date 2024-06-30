using DataAccess.Entities.BaseEntity;

namespace DataAccess.Entities;

public class Exercise : Entity
{
    public string Name { get; set; }
    public List<ExerciseLog> ExerciseLogs { get; set; }
    public Workout Workout { get; set; }
}