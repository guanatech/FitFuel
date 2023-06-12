using Fitfuel.Workouts.Domain.WorkoutAggregate;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Workouts.API;

public static class DependencyInjection 
{
    public static IServiceCollection AddWorkoutsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WorkoutsDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PgSqlConnection")));
        
        return services;
    }
}