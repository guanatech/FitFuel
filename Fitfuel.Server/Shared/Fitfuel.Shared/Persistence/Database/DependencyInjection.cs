using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fitfuel.Shared.Persistence.Database;

public static class DependencyInjection
{
    internal static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHostedService<DbContextAppInitializer>();
        // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        services.ConfigureOptions<PostgresOptionsSetup>();
        var databaseOptions = services.BuildServiceProvider().GetRequiredService<IOptions<PostgresOptions>>()!.Value;
        services.AddDbContext<T>(optionsBuilder =>
        {
            optionsBuilder.UseNpgsql(databaseOptions.ConnectionString, npSqlServerAction =>
            {
                npSqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);

                npSqlServerAction.CommandTimeout(databaseOptions.CommandTimeOut);
            });
            optionsBuilder.EnableDetailedErrors(databaseOptions.EnableDetailedErrors);
            
            // this mode in only dev
            optionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });
        
        return services;
    }
}