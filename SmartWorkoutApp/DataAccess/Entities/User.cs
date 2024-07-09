using DataAccess.Entities.BaseEntity;

namespace DataAccess.Entities;

public class User : Entity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public RoleEnum Role { get; set; } = RoleEnum.Client;
    public double? Weight { get; set; }
    public int? Age { get; set; }
    public Trainer? Trainer { get; set; }
    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();

    public User()
    {
        Trainer = new Trainer();
    }
}