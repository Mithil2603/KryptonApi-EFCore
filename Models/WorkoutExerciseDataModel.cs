namespace KryptonApi_EFCore.Models;

public class WorkoutExerciseDataModel
{
    public int Id { get; set; }

    public required int ExerciseId { get; set; }

    public required int WorkoutId { get; set; }

    public int OrderIndex { get; set; }

    public int Sets { get; set; }

    public int? Reps { get; set; }

    public int? DurationSeconds { get; set; }

    public int RestSeconds { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}