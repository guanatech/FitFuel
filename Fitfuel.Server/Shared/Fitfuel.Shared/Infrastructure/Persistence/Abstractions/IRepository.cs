using Ardalis.Specification;

namespace Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

/// <inheritdoc/>
/// Our base repo, dont change it, but you can create a custom repo if required
public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}
 
/// <inheritdoc/>
/// Repository for queries to read from db, it's also caching in memory
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}