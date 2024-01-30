using ErrorOr;
using Fitfuel.Profiles.Contracts.Achievements;
using Fitfuel.Profiles.Domain.AchievementAggregate;

namespace Fitfuel.Profiles.Application.Common.Interfaces;

public interface IAchievementsService
{
    public Task<ErrorOr<Achievement>> CreateAchievementAsync(CreateAchievementRequest request);
    public Task<ErrorOr<Achievement>> UpdateAchievementAsync(Guid achievementId, UpdateAchievementRequest request);
    public Task<ErrorOr<Guid>> DeleteAchievementAsync(Guid achievementId);
}