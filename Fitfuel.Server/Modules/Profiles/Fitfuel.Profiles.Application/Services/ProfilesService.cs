using ErrorOr;
using Fitfuel.Profiles.Application.Common.Interfaces;
using Fitfuel.Profiles.Contracts.Profiles;
using Fitfuel.Profiles.Domain.Common.Errors;
using Fitfuel.Profiles.Domain.ProfileAggregate;
using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Profiles.Domain.ProfileAggregate.ValueObjects;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

namespace Fitfuel.Profiles.Application.Services;

public class ProfilesService : IProfilesService
{
    private readonly IRepository<Profile> _profileRepository;

    public ProfilesService(IRepository<Profile> profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<ErrorOr<Profile>> UpdateProfileAsync(Guid id, UpdateProfileRequest request)
    {
        var profile = await _profileRepository.GetByIdAsync(id);
        if (profile is null) return Errors.Profile.NotFound;

        var weight = Weight.Create(request.WeightUnit, request.Weight);
        var height = Height.Create(request.HeightUnit, request.Height);
        var updatedProfile = profile.Update(request.FirstName, request.SecondName, request.Age,
        weight, height, (Level)Enum.Parse(typeof(Level), request.Level), request.MainPurpose);
        
        await _profileRepository.UpdateAsync(updatedProfile);
        return profile;
    }

    public async Task<ErrorOr<Guid>> DeleteProfileAsync(Guid profileId)
    {
        var profile = await _profileRepository.GetByIdAsync(profileId);
        if (profile is null) return Errors.Profile.NotFound;

        await _profileRepository.DeleteAsync(profile);
        return profileId;
    }

    public Task UploadAvatarAsync()
    {
        throw new NotImplementedException();
    }
}