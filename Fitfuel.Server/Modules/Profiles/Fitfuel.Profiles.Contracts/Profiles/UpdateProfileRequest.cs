using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;

namespace Fitfuel.Profiles.Contracts.Profiles;

public record UpdateProfileRequest(
    string FirstName, 
    string SecondName,
    int Age,
    double Weight,
    int Height,
    WeightUnit WeightUnit,
    HeightUnit HeightUnit,
    string Level,
    string MainPurpose
    );