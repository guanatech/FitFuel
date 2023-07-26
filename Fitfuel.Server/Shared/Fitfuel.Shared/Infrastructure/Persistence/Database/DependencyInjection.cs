using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Fitfuel.Shared.Infrastructure.Persistence.Database;

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
        services.AddDbContext<T>(options =>
        {
            options.UseNpgsql(databaseOptions.ConnectionString, npSqlServerAction =>
            {
                npSqlServerAction.EnableRetryOnFailure(maxRetryCount: databaseOptions.MaxRetryCount);
                npSqlServerAction.CommandTimeout(databaseOptions.CommandTimeOut);
            });
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            // TODO env if development
            options.EnableDetailedErrors(databaseOptions.EnableDetailedErrors); // to get field-level error details 
            options.EnableSensitiveDataLogging(databaseOptions
                .EnableSensitiveDataLogging); // to get parameter values - do not in production!
            options.ConfigureWarnings(warningAction =>
            {
                warningAction.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning, CoreEventId.RowLimitingOperationWithoutOrderByWarning);
            });
        });

        return services;
    }
}