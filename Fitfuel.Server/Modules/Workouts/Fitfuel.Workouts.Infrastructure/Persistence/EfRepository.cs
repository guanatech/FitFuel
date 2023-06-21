using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Workouts.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Workouts.Infrastructure.Persistence;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly WorkoutsDbContext _dbContext;

    public EfRepository(WorkoutsDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    // Not required to implement anything. Add additional functionalities if required.
}