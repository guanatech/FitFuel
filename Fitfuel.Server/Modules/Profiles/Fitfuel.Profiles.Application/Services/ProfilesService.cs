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
        if (weight.IsError)
            return weight.FirstError;
        
        var height = Height.Create(request.HeightUnit, request.Height);
        if (height.IsError)
            return height.FirstError;
        
        var updatedProfile = profile.Update(request.FirstName, request.SecondName, request.Age,
        weight.Value, height.Value, request.Level, request.MainPurpose);
        if (updatedProfile.IsError)
            return updatedProfile.FirstError;
        
        await _profileRepository.UpdateAsync(updatedProfile.Value);
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