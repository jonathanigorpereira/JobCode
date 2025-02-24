using JobCode.Core.Enums;

namespace JobCode.Application.Models;

public record UserModel(string FirstName,
                        string LastName,
                        DateOnly BirthDate,
                        string Email,
                        string Password,
                        UserType UserType,
                        bool Active,
                        AddressModel Address);

