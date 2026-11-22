using KryptonApi_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace KryptonApi_EFCore.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
    }

    public DbSet<UserDataModel> Users => Set<UserDataModel>();

    public DbSet<ExerciseDataModel> Exercises => Set<ExerciseDataModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}