using KryptonApi_EFCore.Models;
using KryptonApi_EFCore.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KryptonApi_EFCore.Data.Configurations;

public class UserDataModelConfiguration : IEntityTypeConfiguration<UserDataModel>
{
    public void Configure(EntityTypeBuilder<UserDataModel> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Role).IsRequired().HasMaxLength(50).HasDefaultValue(UserType.User);
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
        builder.Property(u => u.UpdatedAt);
    }
}