using Fitfuel.Profiles.Application.Common.Interfaces;
using Fitfuel.Profiles.Contracts.Profiles;
using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Profiles.API.Controllers;

[Route("profiles")]
public class ProfileController : ApiController
{
    private readonly IProfilesService _profileService;

    protected ProfileController(IMapper mapper, IProfilesService profileService) : base(mapper)
    {
        _profileService = profileService;
    }
    
    [HttpGet("{profileId:guid}/achievements")]
    public async Task<IActionResult> GetProfileAchievements(Guid profileId)
    {
        var result = await _profileService.GetProfileAchievementsAsync(profileId);
        return result.Match(
            achievements => Ok(achievements),
            errors => Problem(errors));
    }
    
    [HttpPut("{profileId:guid}")]
    public async Task<IActionResult> UpdateProfile(Guid profileId, UpdateProfileRequest request)
    {
        var result = await _profileService.UpdateProfileAsync(profileId, request);
        return result.Match(
            updatedProfile => Ok(updatedProfile),
            errors => Problem(errors));
    }

    [HttpDelete("{profileId:guid}")]
    public async Task<IActionResult> DeleteProfile(Guid profileId)
    {
        var result = await _profileService.DeleteProfileAsync(profileId);
        return result.Match(
            id => Ok(id),
            errors => Problem(errors));
    }
}