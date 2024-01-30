using Ardalis.Specification.EntityFrameworkCore;
using Fitfuel.Shared.Infrastructure.Persistence.Abstractions;

namespace Fitfuel.Profiles.Infrastructure.Persistence;

public class ProfilesRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly ProfilesDbContext _dbContext;

    public ProfilesRepository(ProfilesDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    
    // Not required to implement anything. Add additional functionalities if required.
}