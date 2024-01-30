using Fitfuel.Workouts.Domain.EquipmentAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate.Enums;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsDbContext : DbContext
{
    public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : base(options) { }
    
    private DbSet<Workout> Workouts { get; set; } = null!;

    private DbSet<Exercise> Exercises { get; set; } = null!;

    private DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;

    private DbSet<Equipment> Equipments { get; set; } = null!;
    
    [Obsolete]
    static WorkoutsDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<ExerciseType>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Level>();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSnakeCaseNamingConvention();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("workouts");
        modelBuilder.HasPostgresEnum<ExerciseType>();
        modelBuilder.HasPostgresEnum<Level>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutsDbContext).Assembly);
    }
}