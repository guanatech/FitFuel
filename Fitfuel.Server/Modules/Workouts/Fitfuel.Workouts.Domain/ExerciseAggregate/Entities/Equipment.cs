using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.ExerciseAggregate.ValueObjects;

namespace Fitfuel.Workouts.Domain.ExerciseAggregate.Entities;

public class Equipment : AggregateRoot<EquipmentId>
{
    public Equipment(EquipmentId id, string name) : base(id) => 
        Name = name; 
    public string Name { get; set; }
    public List<Exercise> Exercises { get; set; } = null!;
    public static Equipment Create(string name) =>
        new(EquipmentId.CreateUnique(), name);
}