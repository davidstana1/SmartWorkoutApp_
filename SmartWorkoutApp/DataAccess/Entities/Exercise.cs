using DataAccess.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public class Exercise : Entity
{
    public string Name { get; set; }
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public List<ExerciseLog> ExerciseLogs { get; set; }
    public Workout Workout { get; set; }
}