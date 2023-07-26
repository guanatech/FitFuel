using Fitfuel.Workouts.Application.Specifications.Workouts;
using FitFuel.Workouts.Contracts.Workouts;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using Mapster;

namespace Fitfuel.Workouts.API.Mappings;

public class WorkoutMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Workout, WorkoutResponse>();
        config.NewConfig<WorkoutFilterRequest, WorkoutFilter>();
    }
}