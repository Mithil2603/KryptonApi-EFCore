namespace KryptonApi_EFCore.Models;

public class SetLogDataModel
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public int ExerciseId { get; set; }

    public int SetNumber { get; set; }

    public int? Reps { get; set; }

    public decimal? WeightKg { get; set; }

    public int? DurationSeconds { get; set; }

    public bool IsCompleted { get; set; } = true;

    public DateTime LoggedAt { get; set; }
}
