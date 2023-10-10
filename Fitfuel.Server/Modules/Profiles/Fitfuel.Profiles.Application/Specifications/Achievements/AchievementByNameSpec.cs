using Ardalis.Specification;
using Fitfuel.Profiles.Domain.AchievementAggregate;

namespace Fitfuel.Profiles.Application.Specifications.Achievements;

public sealed class AchievementByNameSpec : Specification<Achievement>, ISingleResultSpecification<Achievement>
{
    public AchievementByNameSpec(string name) => 
        Query.Where(x => x.Name == name);
}
