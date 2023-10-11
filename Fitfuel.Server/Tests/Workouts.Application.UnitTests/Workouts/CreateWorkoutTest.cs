using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;
using Fitfuel.Workouts.Application.Abstractions;
using Fitfuel.Workouts.Application.Services;
using Fitfuel.Workouts.Domain.WorkoutPlanAggregate.Entities;
using MapsterMapper;
using Moq;

namespace Workouts.Application.UnitTests.Workouts;

public class CreateWorkoutTest
{
    private readonly Mock<IRepository<Workout>> _mockWorkoutRepository;
    private readonly IWorkoutService _workoutService;
    private readonly Mock<IMapper> _mockMapper;

    public CreateWorkoutTest()
    {
        _mockWorkoutRepository = new Mock<IRepository<Workout>>();
        _mockMapper = new Mock<IMapper>();
        _workoutService =new WorkoutService(_mockWorkoutRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task CreateWorkout_WhenWorkoutIsValid_ShouldCreateAndReturnWorkout()
    {
    }
}