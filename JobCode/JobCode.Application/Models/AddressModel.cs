namespace JobCode.Application.Models;

public record AddressModel(string PostalCode,
                          string Avenue,
                          string Street,
                          string District,
                          int LocalNumber,
                          string Complement,
                          string City,
                          string State,
                          string Country);

