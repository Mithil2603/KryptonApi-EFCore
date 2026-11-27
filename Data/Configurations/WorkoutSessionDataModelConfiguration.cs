using KryptonApi_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class WorkoutSessionDataModelConfiguration : IEntityTypeConfiguration<WorkoutSessionDataModel>
{
    public void Configure(EntityTypeBuilder<WorkoutSessionDataModel> builder)
    {
        builder.ToTable("WorkoutSessions");
        builder.HasKey(s => s.Id);

        builder.HasOne<UserDataModel>()
            .WithMany()
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<WorkoutDataModel>()
            .WithMany()
            .HasForeignKey(s => s.WorkoutId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(s => s.UserId);

        builder.Property(s => s.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
    }
}
