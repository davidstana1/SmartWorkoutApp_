using DataAccess.Entities.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public class Workout : Entity
{
    public int? Duration { get; set; }
    public DayEnum Day { get; set; }
    public string Name { get; set; }
    public User User { get; set; } = null!;
    
    [DeleteBehavior(DeleteBehavior.Cascade)]
    public List<Exercise> Exercises { get; set; }
}