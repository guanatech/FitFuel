using Fitfuel.Profiles.Domain.ProfileAggregate.Entities;
using Fitfuel.Profiles.Domain.ProfileAggregate.Enums;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Profiles.Domain.ProfileAggregate;

public class Profile : AggregateRoot
{
    private readonly List<ProfileAchievement> _profileAchievements = new();
    
    public string FirstName { get; private set; }
    
    public string SecondName { get; private set; }
    
    public int Age { get; private set; }
    
    public double Weight { get; private set; }
    
    public int Height { get; private set; }
    
    public Guid UserId { get; private set; }
    
    public Level Level { get; private set; }
    
    public string MainPurpose { get; private set; }

    public IReadOnlyList<ProfileAchievement> ProfileAchievements => _profileAchievements;

    private Profile(Guid id, string firstName, string secondName, int age, double weight, int height, 
        Guid userId, Level level, string mainPurpose) : base(id)
    {
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
        Weight = weight;
        Height = height;
        UserId = userId;
        Level = level;
        MainPurpose = mainPurpose;
    }

    public static Profile Create(string firstName, string secondName, int age, double weight, int height,
        Guid userId, Level level, string mainPurpose) => new(Guid.NewGuid(), firstName, secondName,
        age, weight, height, userId, level, mainPurpose);
}