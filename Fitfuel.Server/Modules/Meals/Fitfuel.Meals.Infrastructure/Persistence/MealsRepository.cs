using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Meals.Application.Common.Interfaces;
using Fitfuel.Shared.Infrastructure.Abstractions;

namespace Fitfuel.Meals.Infrastructure.Persistence;

public class MealsRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly MealsDbContext _dbContext;

    public MealsRepository(MealsDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Not required to implement anything. Add additional functionalities if required.
}