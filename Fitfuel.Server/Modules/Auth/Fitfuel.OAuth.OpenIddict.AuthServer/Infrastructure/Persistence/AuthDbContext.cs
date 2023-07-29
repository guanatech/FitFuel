using Fitfuel.OAuth.OpenIddict.AuthServer.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitfuel.OAuth.OpenIddict.AuthServer.Infrastructure.Persistence;

public class AuthDbContext : DbContext
{
    private DbSet<User> Users { get; set; } = null!;
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
    }
}