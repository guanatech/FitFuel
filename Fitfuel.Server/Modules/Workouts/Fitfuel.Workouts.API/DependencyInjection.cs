using Fitfuel.Shared.Persistence.Database;
using Fitfuel.Workouts.Application;
using Fitfuel.Workouts.Infrastructure;
using Fitfuel.Workouts.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fitfuel.Workouts.API;

public static class DependencyInjection 
{
    public static IServiceCollection AddWorkoutsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddApplication()
            .AddInfrastructure();
        
        services.AddPostgres<WorkoutsDbContext>();

        return services;
    }
}