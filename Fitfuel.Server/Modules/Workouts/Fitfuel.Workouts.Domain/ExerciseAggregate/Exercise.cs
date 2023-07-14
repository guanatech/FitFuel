using Fitfuel.Shared.Entities;
using Fitfuel.Workouts.Domain.EquipmentAggregate;
using Fitfuel.Workouts.Domain.ExerciseAggregate.Enums;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;

namespace Fitfuel.Workouts.Domain.ExerciseAggregate;

public class Exercise : AggregateRoot
{
    private Exercise(
        Guid id,
        Guid workoutId,
        Guid equipmentId,
        string name,
        string description,
        TimeSpan duration,
        ExerciseType exerciseType,
        int repetition)
        : base(id)
    {
        WorkoutId = workoutId;
        EquipmentId = equipmentId;
        Name = name;
        Description = description;
        Duration = duration;
        ExerciseType = exerciseType;
        Repetition = repetition;
    }

    private readonly List<Equipment> _equipments = new ();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public TimeSpan Duration { get; private set; }
    public ExerciseType ExerciseType { get; private set; }
    public int Repetition { get; private set; }
    public Guid WorkoutId { get; private set; }
    
    public bool IsCompleted { get; private set; }
    
    public Guid EquipmentId { get; set; }
    public Workout? Workout { get; set; }
    
    public Equipment? Equipment { get; set; }

    public static Exercise Create(
        Guid workoutId,
        Guid equipmentId,
        string name,
        string description,
        TimeSpan duration,
        ExerciseType exerciseType,
        int repetition) => new(Guid.NewGuid(), workoutId, equipmentId, name, description, duration, exerciseType, repetition);

    public Exercise Update(Guid workoutId, Guid equipmentId, string name, string description, TimeSpan duration, ExerciseType exerciseType, int repetition)
    {
        Name = name;
        Description = description;
        Duration = duration;
        ExerciseType = exerciseType;
        Repetition = repetition;
        WorkoutId = workoutId;
        EquipmentId = equipmentId;
        
        return this;
    }

    public Exercise Complete()
    {
        IsCompleted = true;
        return this;
    }
    
    public void RemoveEquipment(Equipment equipment) =>
        _equipments.Remove(equipment);
    public void AddEquipment(Equipment equipment) =>
        _equipments.Add(equipment);
}