namespace DataAccess.Entities.BaseEntity;

public class ExerciseLog : Entity
{
    public double? Weight { get; set; }
    public int? Sets { get; set; }
    public int? Reps { get; set; }
    public double? Duration { get; set; }
    public double? Distance { get; set; }
    public Exercise Exercise { get; set; }
}