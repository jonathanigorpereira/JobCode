using JobCode.Core.Enums;
using System.Text.Json.Serialization;

namespace JobCode.Core.Entities;

public class User : BaseEntity
{
    public User()
    {
    }

    public User(string firstName,
                string lastName,
                DateOnly birthDate,
                string email,
                string password,
                UserType userType,
                Address? address = null)
        :base()
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        Password = password;
        UserType = userType;
        Role = userType switch
        {
            UserType.Recruiter => "Recruiter",
            UserType.Candidate => "Candidate",
            _ => throw new ArgumentException("Tipo Inválido")
        };
        Active = true;
        Address = address;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; } 
    public UserType UserType { get; private set; }
    public string Role { get; private set; } 
    public bool Active { get; private set; }
    public Address? Address { get; private set; }
}

