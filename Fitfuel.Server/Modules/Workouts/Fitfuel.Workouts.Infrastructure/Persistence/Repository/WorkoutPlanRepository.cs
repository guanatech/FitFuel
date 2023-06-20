using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Workouts.Application.Interfaces;

namespace Fitfuel.Workouts.Infrastructure.Persistence.Repository;

public class WorkoutDbRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    public WorkoutDbRepository(WorkoutsDbContext dbContext) : base(dbContext)
    {
    }
    
    /*protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();*/
}