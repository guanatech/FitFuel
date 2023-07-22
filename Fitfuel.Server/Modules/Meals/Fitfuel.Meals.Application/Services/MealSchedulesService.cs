using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.MealSchedules;
using Fitfuel.Meals.Domain.MealScheduleAggregate;
using ErrorOr;
using Fitfuel.Meals.Domain.Common.Errors;

namespace Fitfuel.Meals.Application.Services;

public class MealSchedulesService : IMealSchedulesService
{
    private readonly IRepository<MealSchedule> _mealSchedulesRepository;

    public MealSchedulesService(IRepository<MealSchedule> mealSchedulesRepository)
    {
        _mealSchedulesRepository = mealSchedulesRepository;
    }

    public async Task<ErrorOr<MealSchedule>> GetMealScheduleAsync(Guid id)
    {
        var schedule = await _mealSchedulesRepository.GetByIdAsync(id);
        
        if(schedule is null)
            return Errors.MealSchedule.MealScheduleNotFound;
        
        return schedule;
    }

    public Task<ErrorOr<MealSchedule>> SetMealScheduleAsync(CreateMealScheduleRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<MealSchedule>> UpdateMealScheduleAsync(UpdateMealScheduleRequest request)
    {
        throw new NotImplementedException();
    }
}