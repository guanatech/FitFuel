using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class WorkoutsRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly WorkoutsDbContext _dbContext;

    public WorkoutsRepository(WorkoutsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    // Not required to implement anything. Add additional functionalities if required.
}