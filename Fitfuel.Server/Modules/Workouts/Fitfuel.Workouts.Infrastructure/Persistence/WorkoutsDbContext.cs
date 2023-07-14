using Fitfuel.Workouts.Domain.EquipmentAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsDbContext : DbContext
{
    private DbSet<Workout> Workouts { get; set; } = null!;

    private DbSet<Exercise> Exercises { get; set; } = null!;

    private DbSet<WorkoutPlan> WorkoutPlans { get; set; } = null!;

    private DbSet<Equipment> Equipments { get; set; } = null!;

    public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("workouts");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}