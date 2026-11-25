using KryptonApi_EFCore.Models;
using KryptonApi_EFCore.Models.Enums;

namespace KryptonApi_EFCore.Data.Seed;

public static class DbSeeder
{
    public static void SeedExercises(ApplicationDbContext context)
    {
        if (context.Exercises.Any())
        {
            return;
        }

        var now = DateTime.UtcNow;

        context.Exercises.AddRange(
            new ExerciseDataModel { Name = "Push-up", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Chest, Equipment = EquipmentEnum.Bodyweight, TrackingType = TrackingTypeEnum.Reps, Description = "Bodyweight chest press performed on the floor.", CreatedAt = now },
            new ExerciseDataModel { Name = "Pull-up", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Back, Equipment = EquipmentEnum.Bodyweight, TrackingType = TrackingTypeEnum.Reps, Description = "Bodyweight back exercise performed on a bar.", CreatedAt = now },
            new ExerciseDataModel { Name = "Bodyweight Squat", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Legs, Equipment = EquipmentEnum.Bodyweight, TrackingType = TrackingTypeEnum.Reps, Description = "Bodyweight squat targeting the legs.", CreatedAt = now },
            new ExerciseDataModel { Name = "Barbell Bench Press", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Chest, Equipment = EquipmentEnum.Barbell, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Barbell press performed lying on a bench.", CreatedAt = now },
            new ExerciseDataModel { Name = "Barbell Back Squat", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Legs, Equipment = EquipmentEnum.Barbell, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Barbell squat with the bar racked on the upper back.", CreatedAt = now },
            new ExerciseDataModel { Name = "Deadlift", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Back, Equipment = EquipmentEnum.Barbell, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Barbell hip-hinge lift from the floor.", CreatedAt = now },
            new ExerciseDataModel { Name = "Dumbbell Shoulder Press", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Shoulders, Equipment = EquipmentEnum.Dumbbell, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Overhead press performed with dumbbells.", CreatedAt = now },
            new ExerciseDataModel { Name = "Dumbbell Bicep Curl", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Arms, Equipment = EquipmentEnum.Dumbbell, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Curl targeting the biceps using dumbbells.", CreatedAt = now },
            new ExerciseDataModel { Name = "Lat Pulldown", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Back, Equipment = EquipmentEnum.Machine, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Cable machine pulldown targeting the lats.", CreatedAt = now },
            new ExerciseDataModel { Name = "Leg Press", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Legs, Equipment = EquipmentEnum.Machine, TrackingType = TrackingTypeEnum.RepsAndWeight, Description = "Machine press targeting the legs.", CreatedAt = now },
            new ExerciseDataModel { Name = "Plank", Category = CategoryEnum.Strength, MuscleGroup = MuscleGroupEnum.Core, Equipment = EquipmentEnum.Bodyweight, TrackingType = TrackingTypeEnum.Time, Description = "Isometric core hold in a straight-body position.", CreatedAt = now },
            new ExerciseDataModel { Name = "Jumping Jacks", Category = CategoryEnum.Cardio, MuscleGroup = MuscleGroupEnum.FullBody, Equipment = EquipmentEnum.None, TrackingType = TrackingTypeEnum.Time, Description = "Full-body cardio warm-up movement.", CreatedAt = now },
            new ExerciseDataModel { Name = "Mountain Climbers", Category = CategoryEnum.Cardio, MuscleGroup = MuscleGroupEnum.Core, Equipment = EquipmentEnum.Bodyweight, TrackingType = TrackingTypeEnum.Time, Description = "Fast-paced cardio movement in a plank position.", CreatedAt = now },
            new ExerciseDataModel { Name = "Downward Dog Stretch", Category = CategoryEnum.Flexibility, MuscleGroup = MuscleGroupEnum.FullBody, Equipment = EquipmentEnum.None, TrackingType = TrackingTypeEnum.Time, Description = "Full-body stretch targeting the shoulders, hamstrings and calves.", CreatedAt = now }
        );

        context.SaveChanges();
    }
}
