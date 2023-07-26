namespace FitFuel.Workouts.Contracts.Equipments;

public record UpdateEquipmentRequest( 
    Guid Id,
    string Name
);