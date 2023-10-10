using Fitfuel.Shared.Entities;

namespace Fitfuel.Profiles.Domain.AchievementAggregate;

public class Achievement : Entity
{
    public string Name { get; private set; }
    
    public string IconUrl { get; private set; }

    private Achievement(Guid id, string name, string iconUrl) : base(id)
    {
        Name = name;
        IconUrl = iconUrl;
    }

    public static Achievement Create(string name, string iconUrl) => 
        new(Guid.NewGuid(), name, iconUrl);

    public Achievement Update(string name, string iconUrl)
    {
        Name = name;
        IconUrl = iconUrl;
        return this;
    }
}