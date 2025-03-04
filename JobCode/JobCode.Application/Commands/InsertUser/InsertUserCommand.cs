using JobCode.Application.Models;
using JobCode.Core.Entities;
using JobCode.Core.Enums;
using MediatR;

namespace JobCode.Application.Commands.InsertUser;

public class InsertUserCommand : IRequest<Result<int>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
    public string Role => UserType.ToString();
    public bool Active { get; set; }
    public Address Address { get; set; }

    public User ToEntity()
       => new(FirstName, LastName, BirthDate, Email, Password, Role, Active);

    
    public void SetPassword(string newPasswordHash)
        => Password = newPasswordHash;

  
    
}

