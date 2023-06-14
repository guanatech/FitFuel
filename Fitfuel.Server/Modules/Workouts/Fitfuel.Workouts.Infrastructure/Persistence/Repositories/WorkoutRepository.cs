using Fitfuel.Shared.Persistence.Specifications;
using Fitfuel.Workouts.Application.Interfaces.Persistence;
using Fitfuel.Workouts.Domain.WorkoutAggregate;

namespace Fitfuel.Workouts.Infrastructure.Persistence.Repositories;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly WorkoutsDbContext _dbContext;
    public WorkoutRepository(WorkoutsDbContext dbContext) =>
        _dbContext = dbContext;

    public IQueryable<Workout> ApplySpecification(
        BaseSpecification<Workout> specification) =>
        SpecificationEvaluator.GetQuery(
            _dbContext.Set<Workout>(),
            specification);

    /*public async Task<User?> GetByLoginAsync(string login) =>
        await _dbContext.Users.SingleOrDefaultAsync(u => u.Name == login);
    
    public async Task<User?> GetByIdAsync(Guid id) =>
        await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    

    public async Task<User> CreateAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetListAsync() => await _dbContext.Users.ToListAsync();

    public async Task UpdateAsync(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }*/
}