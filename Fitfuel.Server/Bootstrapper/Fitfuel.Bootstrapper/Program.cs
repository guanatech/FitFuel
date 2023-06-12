using Fitfuel.Auth.API;
using Fitfuel.Shared;
using Fitfuel.Workouts.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAuthModule(builder.Configuration)
    .AddWorkoutsModule(builder.Configuration)
    .AddSharedFramework(builder.Configuration);

var app = builder.Build();
{
    app.UseSharedFramework(app.Environment);
    app.MapControllers();
}
app.Run();