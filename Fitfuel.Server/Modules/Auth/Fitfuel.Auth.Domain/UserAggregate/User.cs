using Fitfuel.Auth.Domain.UserAggregate.Enums;
using Fitfuel.Auth.Domain.UserAggregate.ValueObjects;
using Fitfuel.Shared.Entities;

namespace Fitfuel.Auth.Domain.UserAggregate;

public class User : AggregateRoot
{
    public string Username { get; private set; }

    public string PasswordHash { get; init; }

    public Role Role { get; private set; }

    public Email Email { get; private set; }

    public string PhoneNumber { get; private set; }

    public DateTime CreatedDate { get; private set; }

    public DateTime UpdatedDate { get; private set; }

    private User(Guid id, string username, string passwordHash, Role role, Email email,
        string phoneNumber) : base(id)
    {
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
        Email = email;
        PhoneNumber = phoneNumber;
        CreatedDate = DateTime.UtcNow;
        UpdatedDate = DateTime.UtcNow;
    }

    public static User Create(string username, string passwordHash, Role role, Email email, string phoneNumber) => 
        new(Guid.NewGuid(), username, passwordHash, role, email, phoneNumber);
}