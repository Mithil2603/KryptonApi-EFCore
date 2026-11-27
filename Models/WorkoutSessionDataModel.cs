using KryptonApi_EFCore.Models.Enums;

namespace KryptonApi_EFCore.Models;

public class WorkoutSessionDataModel
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int WorkoutId { get; set; }

    public int? ProgramDayId { get; set; }

    public DateTime StartedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public WorkoutSessionEnum Status { get; set; }

    public int DurationSeconds { get; set; }

    public int TotalSets { get; set; }

    public int TotalReps { get; set; }

    public int TotalVolumeKg { get; set; }

    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}