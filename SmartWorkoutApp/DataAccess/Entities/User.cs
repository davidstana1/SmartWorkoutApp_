namespace DataAccess.Entities;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public double? Weight { get; set; }
    public int? Age { get; set; }
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}