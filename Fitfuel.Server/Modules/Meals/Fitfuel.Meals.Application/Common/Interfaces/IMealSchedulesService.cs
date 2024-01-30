using Fitfuel.Meals.Contracts.MealSchedules;
using Fitfuel.Meals.Domain.MealScheduleAggregate;
using ErrorOr;

namespace Fitfuel.Meals.Application.Common.Interfaces;

public interface IMealSchedulesService
{
    Task<ErrorOr<MealSchedule>> GetMealScheduleAsync(Guid profileId);
    
    Task<ErrorOr<MealSchedule>> SetMealScheduleAsync(CreateMealScheduleRequest request);
    Task<ErrorOr<MealSchedule>> UpdateMealScheduleAsync(UpdateMealScheduleRequest request);
}