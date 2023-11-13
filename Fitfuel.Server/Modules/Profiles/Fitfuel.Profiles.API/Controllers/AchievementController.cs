using Fitfuel.Profiles.Application.Common.Interfaces;
using Fitfuel.Profiles.Contracts.Achievements;
using Fitfuel.Shared.Presentation;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Profiles.API.Controllers;

[Route("achievements")]
public class AchievementController : ApiController
{
    private readonly IAchievementsService _achievementsService;
    
    protected AchievementController(IMapper mapper, IAchievementsService achievementsService) : base(mapper)
    {
        _achievementsService = achievementsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAchievement(CreateAchievementRequest request)
    {
        var result = await _achievementsService.CreateAchievementAsync(request);
        return result.Match(
            achievement => Ok(achievement),
            errors => Problem(errors));
    }
    
    [HttpPut("{achievementId:guid}")]
    public async Task<IActionResult> UpdateAchievement(Guid achievementId, UpdateAchievementRequest request)
    {
        var result = await _achievementsService.UpdateAchievementAsync(achievementId, request);
        return result.Match(
            updatedAchievement => Ok(updatedAchievement),
            errors => Problem(errors));
    }
    
    [HttpDelete("{achievementId:guid}")]
    public async Task<IActionResult> DeleteAchievement(Guid achievementId)
    {
        var result = await _achievementsService.DeleteAchievementAsync(achievementId);
        return result.Match(
            id => Ok(id),
            errors => Problem(errors));
    }
}