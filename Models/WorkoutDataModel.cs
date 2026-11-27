namespace KryptonApi_EFCore.Models;

public class WorkoutDataModel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public Guid? OwnerUserId { get; set; }

    public int? SourceWorkoutId { get; set; }

    public string? Location { get; set; }

    public int EstimatedMinutes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
