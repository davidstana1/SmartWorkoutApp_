namespace DataAccess.Entities;

public class Workout
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public int? Duration { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; } = null!;
}