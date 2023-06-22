using Fitfuel.Shared.Persistence.Database;
using Fitfuel.Shared.Presentation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fitfuel.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostgres(configuration);
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddSharedPresentation();
        
        
        // Add base repos
        return services;
    }

    public static IApplicationBuilder UseSharedFramework(this IApplicationBuilder app,  IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        return app;
    }
}