namespace Fitfuel.Profiles.Contracts.Profiles;

public record UpdateProfileRequest(
    string FirstName, 
    string SecondName,
    int Age,
    double Weight,
    int Height,
    string WeightUnit,
    string HeightUnit,
    string Level,
    string MainPurpose
    );