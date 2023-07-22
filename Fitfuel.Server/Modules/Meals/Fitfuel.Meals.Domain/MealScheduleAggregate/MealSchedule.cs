using Fitfuel.Shared.Entities;

namespace Fitfuel.Meals.Domain.MealScheduleAggregate;

public class MealSchedule : AggregateRoot
{
    public TimeSpan BreakfastTime { get; private set; }
    
    public TimeSpan LunchTime { get; private set; }

    public TimeSpan DinnerTime { get; private set; }

    public Guid ProfileId { get; init; }
    
    public bool IsNotified { get; private set; }
    
    private MealSchedule(Guid id, TimeSpan breakfastTime, TimeSpan lunchTime, TimeSpan dinnerTime, Guid profileId, 
        bool isNotified) : base(id)
    {
        BreakfastTime = breakfastTime;
        LunchTime = lunchTime;
        DinnerTime = dinnerTime;
        ProfileId = profileId;
        IsNotified = isNotified;
    }

    public static MealSchedule Create(TimeSpan breakfastTime, TimeSpan lunchTime, TimeSpan dinnerTime, Guid profileId,
        bool isNotified) => new(Guid.NewGuid(), breakfastTime, lunchTime, dinnerTime, profileId, isNotified);

    //TODO: add ChangeNotify method
    public MealSchedule Update(TimeSpan breakfastTime, TimeSpan lunchTime, TimeSpan dinnerTime, bool isNotified)
    {
        BreakfastTime = breakfastTime;
        LunchTime = lunchTime;
        DinnerTime = dinnerTime;
        IsNotified = isNotified;

        return this;
    }
}