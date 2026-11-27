using KryptonApi_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class WorkoutDataModelConfiguration : IEntityTypeConfiguration<WorkoutDataModel>
{
    public void Configure(EntityTypeBuilder<WorkoutDataModel> builder)
    {
        builder.ToTable("Workouts");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name).IsRequired().HasMaxLength(100);

        builder.HasOne<UserDataModel>().WithMany().HasForeignKey(w => w.OwnerUserId).OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WorkoutDataModel>().WithMany().HasForeignKey(w => w.SourceWorkoutId).OnDelete(DeleteBehavior.Restrict);

        builder.Property(w => w.Location).HasMaxLength(10);

        builder.Property(e => e.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}