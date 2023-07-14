using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.EquipmentAggregate.ValueObjects;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Domain.EquipmentAggregate;

public class Equipment : AggregateRoot
{
    public Equipment(Guid id, string name) : base(id) => 
        Name = name; 
    public string Name { get; set; }
    public List<Exercise> Exercises { get; set; } = null!;
    public static Equipment Create(string name) =>
        new(Guid.NewGuid(), name);
}