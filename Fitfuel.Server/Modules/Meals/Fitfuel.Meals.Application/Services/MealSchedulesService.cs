using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Meals.Contracts.MealSchedules;
using Fitfuel.Meals.Domain.MealScheduleAggregate;
using Fitfuel.Meals.Domain.Common.Errors;
using ErrorOr;
using Fitfuel.Meals.Application.Specifications.MealSchedules;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

namespace Fitfuel.Meals.Application.Services;

public class MealSchedulesService : IMealSchedulesService
{
    private readonly IRepository<MealSchedule> _mealSchedulesRepository;

    public MealSchedulesService(IRepository<MealSchedule> mealSchedulesRepository)
    {
        _mealSchedulesRepository = mealSchedulesRepository;
    }

    public async Task<ErrorOr<MealSchedule>> GetMealScheduleAsync(Guid profileId)
    {
        var spec = new MealScheduleByProfileIdSpec(profileId);
        if (await _mealSchedulesRepository.FirstOrDefaultAsync(spec) is not { } schedule)
            return Errors.MealSchedule.MealScheduleNotFound;
        
        return schedule;
    }

    public async Task<ErrorOr<MealSchedule>> SetMealScheduleAsync(CreateMealScheduleRequest request)
    {
        var spec = new MealScheduleByProfileIdSpec(request.ProfileId);
        
        if (await _mealSchedulesRepository.FirstOrDefaultAsync(spec) is not null)
            return Errors.MealSchedule.MealScheduleAlreadyExist;
        
        var mealSchedule = MealSchedule.Create(request.BreakfastTime,
            request.LunchTime, request.DinnerTime, request.ProfileId, request.IsNotified);

        await _mealSchedulesRepository.AddAsync(mealSchedule);
        return mealSchedule;
    }

    public async Task<ErrorOr<MealSchedule>> UpdateMealScheduleAsync(UpdateMealScheduleRequest request)
    {
        var result = await GetMealScheduleAsync(request.ProfileId);
        if (result.IsError) return result.FirstError;
        
        var updatedSchedule = result.Value.Update(request.BreakfastTime, request.LunchTime, request.DinnerTime,
            request.IsNotified);
        
        return updatedSchedule;
    }
}