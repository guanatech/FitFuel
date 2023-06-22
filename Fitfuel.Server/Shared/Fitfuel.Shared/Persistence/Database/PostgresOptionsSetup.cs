using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Fitfuel.Shared.Persistence.Database;

public class PostgresOptionsSetup : IConfigureOptions<PostgresOptions>
{
    private const string ConfigurationSectionName = "DatabaseOptions";

    private readonly IConfiguration _configuration;

    public PostgresOptionsSetup(IConfiguration configuration) =>
        _configuration = configuration;

    public void Configure(PostgresOptions options)
    {
        var connectionString = _configuration[$"Postgres:{nameof(PostgresOptions.ConnectionString)}"];

        options.ConnectionString = connectionString;
        
        _configuration.GetSection(ConfigurationSectionName).Bind(options);
    }
}