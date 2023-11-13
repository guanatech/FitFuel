using Fitfuel.Meals.Domain.MealAggregate;
using Fitfuel.Meals.Domain.MealScheduleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Meals.Infrastructure.Persistence;

public class MealsDbContext : DbContext
{
    public DbSet<Meal> Meals { get; set; } = null!;
    public DbSet<MealSchedule> MealSchedules { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseCamelCaseNamingConvention();
    public MealsDbContext(DbContextOptions<MealsDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("meals");
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}