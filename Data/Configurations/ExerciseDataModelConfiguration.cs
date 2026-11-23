using KryptonApi_EFCore.Models;
using KryptonApi_EFCore.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class ExerciseDataModelConfiguration : IEntityTypeConfiguration<ExerciseDataModel>
{
    public void Configure(EntityTypeBuilder<ExerciseDataModel> builder)
    {
        builder.ToTable("Exercises");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.HasIndex(e => e.Name).IsUnique();

        builder.Property(e => e.IsActive).HasDefaultValue(true);
        builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(e => e.TrackingType).HasDefaultValue(TrackingTypeEnum.Reps);

        builder.HasIndex(e => new { e.Equipment, e.MuscleGroup });
    }
}