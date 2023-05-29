using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        // configure models
    }
}