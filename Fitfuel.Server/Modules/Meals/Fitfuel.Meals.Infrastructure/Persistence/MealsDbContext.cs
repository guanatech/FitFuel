using Fitfuel.Meals.Domain.Common.Enums;
using Fitfuel.Meals.Domain.MealAggregate;
using Fitfuel.Meals.Domain.MealAggregate.Enums;
using Fitfuel.Meals.Domain.MealScheduleAggregate;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Fitfuel.Meals.Infrastructure.Persistence;

public class MealsDbContext : DbContext
{
    public DbSet<Meal> Meals { get; set; } = null!;
    public DbSet<MealSchedule> MealSchedules { get; set; } = null!;

    [Obsolete]
    static MealsDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Category>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<ActivityRate>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<TrainingTarget>();
    }
    
    public MealsDbContext(DbContextOptions<MealsDbContext> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("meals");
        modelBuilder.HasPostgresEnum<Category>();
        modelBuilder.HasPostgresEnum<ActivityRate>();
        modelBuilder.HasPostgresEnum<TrainingTarget>();
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}