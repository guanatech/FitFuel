﻿using Fitfuel.Meals.Infrastructure.Persistence;
using Fitfuel.Shared.Infrastructure.Abstractions;
using Fitfuel.Shared.Infrastructure.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Meals.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistence();
        return services;
    }
    
    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddPostgres<MealsDbContext>();
        services.AddScoped(typeof(IRepository<>),typeof(MealsRepository<>));
        return services;
    }
}