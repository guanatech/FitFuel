using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.ExerciseAggregate;

namespace Fitfuel.Workouts.Domain.EquipmentAggregate;

public class Equipment : AggregateRoot
{
    public Equipment(Guid id, string name) : base(id) => 
        Name = name;

    private readonly List<Exercise> _exercises = new ();
    public string Name { get; set; }
    public IReadOnlyList<Exercise> Exercises => _exercises.AsReadOnly();
    public static Equipment Create(string name) =>
        new(Guid.NewGuid(), name);

    public Equipment Update(string name)
    {
        Name = name;
        return this;
    }

    public void RemoveExercise(Exercise exercise) =>
        _exercises.Remove(exercise);
    public void AddExercise(Exercise exercise) =>
        _exercises.Add(exercise);
}