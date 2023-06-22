using Fitfuel.Shared;
using Fitfuel.Workouts.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWorkoutsModule(builder.Configuration)
    .AddSharedFramework(builder.Configuration, builder.Host);
    //.AddAuthModule(builder.Configuration)

var app = builder.Build();
{
    app.UseSharedFramework(app.Environment);
    app.MapControllers();
}
app.Run();