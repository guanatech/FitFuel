using Fitfuel.Workouts.Application.Specifications.WorkoutPlans;
using FitFuel.Workouts.Contracts.WorkoutPlans;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate;
using Mapster;

namespace Fitfuel.Workouts.API.Mappings;

public class WorkoutPlanMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<WorkoutPlan, WorkoutPlanResponse>();
        config.NewConfig<WorkoutPlanFilter, WorkoutPlanFilterRequest>();
    }
}