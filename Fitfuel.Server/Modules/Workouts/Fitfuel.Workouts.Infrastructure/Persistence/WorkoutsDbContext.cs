using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsDbContext : DbContext
{
    public WorkoutsDbContext(DbContextOptions<WorkoutsDbContext> options): base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("workouts");
        // configure models
    }
}