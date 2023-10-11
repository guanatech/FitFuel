using ErrorOr;
using Fitfuel.Profiles.Contracts.Profiles;
using Fitfuel.Profiles.Domain.ProfileAggregate;

namespace Fitfuel.Profiles.Application.Common.Interfaces;

public interface IProfilesService
{
    Task<ErrorOr<Profile>> UpdateProfileAsync(Guid id, UpdateProfileRequest request);
    Task<ErrorOr<Guid>> DeleteProfileAsync(Guid profileId);
    Task UploadAvatarAsync();
}