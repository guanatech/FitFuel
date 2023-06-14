using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Fitfuel.Workouts.Domain.WorkoutAggregate;
using Fitfuel.Workouts.Infrastructure.Persistence.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsDbContext : DbContext
{
    private DbSet<Workout> Workouts { get; set; } = null!;

    private DbSet<Exercise> Exercises { get; set; } = null!;
    
    public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("workouts");
        modelBuilder.ApplyConfiguration(new WorkoutEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ExerciseEntityConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}

