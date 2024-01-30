using Ardalis.Specification;
using Fitfuel.Meals.Domain.MealScheduleAggregate;

namespace Fitfuel.Meals.Application.Specifications.MealSchedules;

public sealed class MealScheduleByProfileIdSpec : Specification<MealSchedule>,
    ISingleResultSpecification<MealSchedule>
{
    public MealScheduleByProfileIdSpec(Guid profileId) =>
        Query.Where(schedule => schedule.ProfileId == profileId);
}