using DataAccess.Entities.BaseEntity;

namespace DataAccess.Entities;

public class Workout : Entity
{
    public int? Duration { get; set; }
    public DayEnum Day { get; set; }
    public string Name { get; set; }
    public User User { get; set; } = null!;
    public List<Exercise> Exercises { get; set; }
}