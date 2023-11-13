using ErrorOr;
using Fitfuel.Profiles.Application.Common.Interfaces;
using Fitfuel.Profiles.Application.Specifications.Achievements;
using Fitfuel.Profiles.Contracts.Achievements;
using Fitfuel.Profiles.Domain.AchievementAggregate;
using Fitfuel.Profiles.Domain.Common.Errors;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

namespace Fitfuel.Profiles.Application.Services;

public class AchievementsService : IAchievementsService
{
    private readonly IRepository<Achievement> _achievementRepository;

    public AchievementsService(IRepository<Achievement> achievementRepository)
    {
        _achievementRepository = achievementRepository;
    }

    public async Task<ErrorOr<Achievement>> CreateAchievementAsync(CreateAchievementRequest request)
    {
        if(await _achievementRepository.FirstOrDefaultAsync(new AchievementByNameSpec(request.Name)) is not null)
            return Errors.Achievement.NameAlreadyExists;

        var achievement = Achievement.Create(request.Name, "linkToImage");
        return achievement;
    }

    public async Task<ErrorOr<Achievement>> UpdateAchievementAsync(Guid achievementId, UpdateAchievementRequest request)
    {
        var achievement = await _achievementRepository.GetByIdAsync(achievementId);
        if (achievement is null) return Errors.Achievement.NotFound;
        
        if(await _achievementRepository.FirstOrDefaultAsync(new AchievementByNameSpec(request.Name)) is not null)
            return Errors.Achievement.NameAlreadyExists;

        var updatedAchievement = achievement.Update(request.Name, "UpdatedLinkToImage");
        return updatedAchievement;
    }

    public async Task<ErrorOr<Guid>> DeleteAchievementAsync(Guid achievementId)
    {
        var achievement = await _achievementRepository.GetByIdAsync(achievementId);
        if (achievement is null) return Errors.Achievement.NotFound;

        await _achievementRepository.DeleteAsync(achievement);
        return achievementId;
    }
}