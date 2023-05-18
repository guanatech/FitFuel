using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Shared.Database;

public static class DependencyInjection
{
    private const string SectionName = "Postgres";
        
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        //services.Configure<PostgresOptions>(configuration.GetConnectionString());
        //services.AddHostedService<DbContextAppInitializer>();
                        
        // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        

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