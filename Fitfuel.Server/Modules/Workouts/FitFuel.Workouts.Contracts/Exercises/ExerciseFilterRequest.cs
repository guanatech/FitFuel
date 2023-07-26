using Fitfuel.Shared.Infrastructure.Persistence.Specifications.Filters;
using Fitfuel.Workouts.Domain.ExerciseAggregate.Enums;

namespace FitFuel.Workouts.Contracts.Exercises;

public class ExerciseFilterRequest : BaseFilter
{
    public string Name { get; init; }
    public string Description { get; init; }
    public DateTime Duration { get; init; }
    public ExerciseType ExerciseType { get; init; }
    public int Repetition { get; init; }
    public Guid? EquipmentId { get; init; }
}