using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealScheduleAggregate;

public class MealSchedule : AggregateRoot
{
    public string BreakfastTime { get; private set; }
    
    public string LunchTime { get; private set; }

    public string DinnerTime { get; private set; }

    public Guid ProfileId { get; init; }
    
    public bool IsNotified { get; private set; }
    
    private MealSchedule(Guid id, string breakfastTime, string lunchTime, string dinnerTime, Guid profileId, 
        bool isNotified) : base(id)
    {
        BreakfastTime = breakfastTime;
        LunchTime = lunchTime;
        DinnerTime = dinnerTime;
        ProfileId = profileId;
        IsNotified = isNotified;
    }

    public static MealSchedule Create(string breakfastTime, string lunchTime, string dinnerTime, Guid profileId,
        bool isNotified) => new(Guid.NewGuid(), breakfastTime, lunchTime, dinnerTime, profileId, isNotified);

    //TODO: add ChangeNotify method
    public MealSchedule Update(string breakfastTime, string lunchTime, string dinnerTime, bool isNotified)
    {
        BreakfastTime = breakfastTime;
        LunchTime = lunchTime;
        DinnerTime = dinnerTime;
        IsNotified = isNotified;

        return this;
    }
}