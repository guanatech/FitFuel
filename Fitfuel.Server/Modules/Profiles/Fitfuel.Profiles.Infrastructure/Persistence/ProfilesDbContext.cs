using Fitfuel.Profiles.Domain.AchievementAggregate;
using Fitfuel.Profiles.Domain.ProfileAggregate;
using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Fitfuel.Profiles.Infrastructure.Persistence;

public class ProfilesDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; } = null!;
    public DbSet<Achievement> Achievements { get; set; } = null!;

    public ProfilesDbContext(DbContextOptions<ProfilesDbContext> options) : base(options) { }

    [Obsolete]
    static ProfilesDbContext()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<HeightUnit>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<WeightUnit>();
        NpgsqlConnection.GlobalTypeMapper.MapEnum<Level>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("profiles");
        modelBuilder.HasPostgresEnum<HeightUnit>();
        modelBuilder.HasPostgresEnum<WeightUnit>();
        modelBuilder.HasPostgresEnum<Level>();
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProfilesDbContext).Assembly);
    }
}