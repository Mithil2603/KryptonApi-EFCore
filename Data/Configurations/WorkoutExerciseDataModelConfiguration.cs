using KryptonApi_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class WorkoutExerciseDataModelConfiguration : IEntityTypeConfiguration<WorkoutExerciseDataModel>
{
    public void Configure(EntityTypeBuilder<WorkoutExerciseDataModel> builder)
    {
        builder.ToTable("WorkoutExercises");
        builder.HasKey(we => we.Id);

        builder.HasOne<ExerciseDataModel>().WithMany().HasForeignKey(we => we.ExerciseId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<WorkoutDataModel>().WithMany().HasForeignKey(we => we.WorkoutId).OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(we => we.WorkoutId);

        builder.Property(we => we.OrderIndex).IsRequired();
        builder.Property(we => we.Sets).IsRequired();
        builder.Property(we => we.RestSeconds).IsRequired();

        builder.Property(we => we.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}