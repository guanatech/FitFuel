using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Shared.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Shared.Persistence.Repositories;

public class DbRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly DbContext _dbContext;

    public DbRepository(DbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    // Not required to implement anything. Add additional functionalities if required.
}