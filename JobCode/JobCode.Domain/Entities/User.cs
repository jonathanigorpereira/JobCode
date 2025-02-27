using JobCode.Core.Enums;
using System.Text.Json.Serialization;

namespace JobCode.Core.Entities;

public class User(string firstName,
            string lastName,
            DateOnly birthDate,
            string email,
            string password,
            string role,
            bool active
           ) : BaseEntity()
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public DateOnly BirthDate { get; private set; } = birthDate;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public string Role { get; private set; } = role;
    public bool Active { get; private set; } = active;
    public Address Address { get; private set; }

    public void SetAddress(Address address)
        => Address = address;
}

