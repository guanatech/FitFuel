using Fitfuel.Workouts.Application.Specifications.Equipments;
using FitFuel.Workouts.Contracts.Equipments;
using Fitfuel.Workouts.Domain.EquipmentAggregate;
using Mapster;

namespace Fitfuel.Workouts.API.Mappings;

public class EquipmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Equipment, EquipmentResponse>();
        config.NewConfig<EquipmentFilterRequest, EquipmentFilter>();
    }
}