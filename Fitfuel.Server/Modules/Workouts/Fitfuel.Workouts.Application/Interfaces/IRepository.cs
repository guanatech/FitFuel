using Ardalis.Specification;

namespace Fitfuel.Workouts.Application.Interfaces;

public interface IRepository<T> : IRepositoryBase<T>
    where T : class
{
}