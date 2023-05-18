using Fitfuel.Auth.API;
using Fitfuel.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthModule(builder.Configuration)
    .AddSharedFramework(builder.Configuration);

var app = builder.Build();
{
    app.UseSharedFramework(app.Environment);
    app.MapControllers();
}
app.Run();