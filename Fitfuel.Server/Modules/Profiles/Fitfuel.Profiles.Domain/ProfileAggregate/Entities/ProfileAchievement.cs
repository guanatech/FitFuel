using Fitfuel.Profiles.Domain.AchievementAggregate;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Profiles.Domain.ProfileAggregate.Entities;

public class ProfileAchievement : Entity
{
    public Guid ProfileId { get; init; }
    
    public Guid AchievementId { get; init; }

    public Profile Profile { get; set; } = null!;
    public Achievement Achievement { get; set; } = null!;

    public ProfileAchievement(Guid id, Guid profileId, Guid achievementId) : base(id)
    {
        ProfileId = profileId;
        AchievementId = achievementId;
    }
}