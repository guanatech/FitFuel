using Fitfuel.Workouts.Application.Specifications.Exercises;
using FitFuel.Workouts.Contracts.Exercises;
using Fitfuel.Workouts.Domain.ExerciseAggregate;
using Mapster;

namespace Fitfuel.Workouts.API.Mappings;

public class ExerciseMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Exercise, ExerciseResponse>();
        config.NewConfig<ExerciseFilterRequest, ExerciseFilter>();
    }
}