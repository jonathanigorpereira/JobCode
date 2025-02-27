namespace JobCode.Core.Entities;

public class Address(string postalCode, string avenue, string street, string district, int localNumber, int complement, string city, string state, string country) : BaseEntity()
{
    public string PostalCode { get; private set; } = postalCode;
    public string Avenue { get; private set; } = avenue;
    public string Street { get; private set; } = street;
    public string District { get; private set; } = district;
    public int LocalNumber { get; private set; } = localNumber;
    public int Complement { get; private set; } = complement;
    public string City { get; private set; } = city;
    public string State { get; private set; } = state;
    public string Country { get; private set; } = country;
}

