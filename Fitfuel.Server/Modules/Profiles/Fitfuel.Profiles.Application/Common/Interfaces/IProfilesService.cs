using ErrorOr;
using Fitfuel.Profiles.Contracts.Profiles;
using Fitfuel.Profiles.Domain.ProfileAggregate;
using Fitfuel.Profiles.Domain.ProfileAggregate.Entities;

namespace Fitfuel.Profiles.Application.Common.Interfaces;

public interface IProfilesService
{
    Task<ErrorOr<List<ProfileAchievement>>> GetProfileAchievementsAsync(Guid profileId);
    
    Task<ErrorOr<Profile>> UpdateProfileAsync(Guid id, UpdateProfileRequest request);
    Task<ErrorOr<Guid>> DeleteProfileAsync(Guid profileId);
    Task UploadAvatarAsync();
}