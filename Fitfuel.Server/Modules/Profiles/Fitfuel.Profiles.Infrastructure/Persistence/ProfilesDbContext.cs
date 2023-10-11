using Fitfuel.Profiles.Domain.AchievementAggregate;
using Fitfuel.Profiles.Domain.ProfileAggregate;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Profiles.Infrastructure.Persistence;

public class ProfilesDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; } = null!;
    public DbSet<Achievement> Achievements { get; set; } = null!;

    public ProfilesDbContext(DbContextOptions<ProfilesDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("profiles");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfilesDbContext).Assembly);
    }
}