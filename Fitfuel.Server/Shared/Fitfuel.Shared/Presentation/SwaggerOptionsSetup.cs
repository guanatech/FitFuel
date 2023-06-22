using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Fitfuel.Shared.Presentation;

public class SwaggerOptionsSetup : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerOptionsSetup(IApiVersionDescriptionProvider provider) =>
        _provider = provider;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in _provider.ApiVersionDescriptions)
        {
            var apiVersion = description.ApiVersion.ToString();
            options.SwaggerDoc(description.GroupName,
                new OpenApiInfo
                {
                    Version = apiVersion,
                    Title = $"FitFuel API {apiVersion}",
                    Description = "ASP NET Core Web API for FitFuel"
                });
        }
    }
    
}