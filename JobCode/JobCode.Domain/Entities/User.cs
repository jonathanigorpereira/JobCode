using JobCode.Core.Enums;

namespace JobCode.Core.Entities;

public class User : BaseEntity
{
    public User(string firstName, string lastName, DateTime birthDate, string email, string password, UserType userType)
        :base()
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        Password = password;
        UserType = userType;
        Active = true;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; } 
    public UserType UserType { get; private set; }
    public string Role { get; set; } = string.Empty;
    public bool Active { get; private set; }
    public int? CompanyId { get; set; }
    public Company? Company { get; set; }

}

