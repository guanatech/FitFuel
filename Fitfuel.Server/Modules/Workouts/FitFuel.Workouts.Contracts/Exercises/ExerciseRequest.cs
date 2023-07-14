﻿using Fitfuel.Workouts.Domain.ExerciseAggregate.Enums;

namespace FitFuel.Workouts.Contracts.Exercises;

public record ExerciseRequest(Guid Id,
    Guid WorkoutId,
    Guid EquipmentId,
    string Name,
    string Description, 
    TimeSpan Duration, 
    ExerciseType ExerciseType,
    int Repetition
);