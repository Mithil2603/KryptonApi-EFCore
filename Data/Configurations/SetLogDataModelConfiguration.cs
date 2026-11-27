using KryptonApi_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class SetLogDataModelConfiguration : IEntityTypeConfiguration<SetLogDataModel>
{
    public void Configure(EntityTypeBuilder<SetLogDataModel> builder)
    {
        builder.ToTable("SetLogs");
        builder.HasKey(s => s.Id);

        builder.HasOne<WorkoutSessionDataModel>()
            .WithMany()
            .HasForeignKey(s => s.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ExerciseDataModel>()
            .WithMany()
            .HasForeignKey(s => s.ExerciseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(s => s.SessionId);
        builder.HasIndex(s => s.ExerciseId);

        builder.Property(s => s.WeightKg).HasColumnType("decimal(6,2)");
    }
}
