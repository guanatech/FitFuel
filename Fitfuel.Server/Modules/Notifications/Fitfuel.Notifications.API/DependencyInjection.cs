using Fitfuel.Notifications.API.Services;
using Fitfuel.Notifications.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fitfuel.Notifications.API;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailResolver, EmailResolver>();
        services.Configure<EmailOptions>(configuration.GetSection(EmailOptions.SectionName));
        
        return services;
    }
    
    public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
    {
        return app;
    }
}