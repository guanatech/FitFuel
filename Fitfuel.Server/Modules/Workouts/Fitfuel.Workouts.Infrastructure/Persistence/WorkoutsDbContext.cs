using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate.Entities;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Fitfuel.Workouts.Infrastructure.Persistence.EntitiesConfigurations;
using Microsoft.EntityFrameworkCore;

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
        /*modelBuilder.ApplyConfiguration(new WorkoutEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EquipmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkoutPlanEntityConfiguration());*/
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkoutsDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

