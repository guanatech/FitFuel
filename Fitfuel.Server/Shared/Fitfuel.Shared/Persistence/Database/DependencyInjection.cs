using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Shared.Persistence.Database;

public static class DependencyInjection
{
    private const string SectionName = "Postgres";
        
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        /*services.Configure<PostgresOptions>(configuration.GetSection(SectionName));
        services.AddHostedService<DbContextAppInitializer>();
                        
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);*/
        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var connectionString = configuration[$"{SectionName}:{nameof(PostgresOptions.ConnectionString)}"];
        services.AddDbContext<T>(x => x.UseNpgsql(connectionString));

        return services;
    }
}