using KryptonApi_EFCore.Models.Enums;

namespace KryptonApi_EFCore.Models;

public class ExerciseDataModel
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public CategoryEnum Category { get; set; }

    public MuscleGroupEnum MuscleGroup { get; set; }

    public EquipmentEnum Equipment { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}