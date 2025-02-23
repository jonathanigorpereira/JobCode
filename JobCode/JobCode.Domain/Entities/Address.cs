namespace JobCode.Core.Entities;

public class Address(Address.AddressInfo info) : BaseEntity()
{
    public record AddressInfo(
           string PostalCode,
           string Avenue,
           string Street,
           string District,
           int LocalNumber,
           string City,
           string State,
           string Country);

    public string PostalCode { get; private set; } = info.PostalCode;
    public string Avenue { get; private set; } = info.Avenue;
    public string Street { get; private set; } = info.Street;
    public string District { get; private set; } = info.District;
    public int LocalNumber { get; private set; } = info.LocalNumber;
    public string City { get; private set; } = info.City;
    public string State { get; private set; } = info.State;
    public string Country { get; private set; } = info.Country;
}

