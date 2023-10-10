using Fitfuel.Meals.API;
using Fitfuel.Notifications.API;
using Fitfuel.Profiles.API;
using Fitfuel.Shared;
using Fitfuel.Workouts.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    //.AddWorkoutsModule()
    .AddNotificationsModule(builder.Configuration)
    .AddProfilesModule()
    .AddMealsModule()
    //.AddAuthModule(builder.Configuration)
    .AddSharedFramework(builder.Configuration, builder.Host);
    

var app = builder.Build();
{
    app.UseSharedFramework(app.Environment);
    app.UseNotificationsModule();
    app.MapControllers();
}
app.Run();