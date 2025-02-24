namespace JobCode.Core.Entities;

public class Address : BaseEntity
{
    public Address()
    {
    }

    public struct AddressStruct
    {
        public string PostalCode { get; set; }
        public string Avenue { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public int LocalNumber { get; set; }
        public int Complement { get;  set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }

    public Address(AddressStruct address)
        :base()
    {
        PostalCode = address.PostalCode;
        Avenue = address.Avenue;
        Street = address.Street;
        District = address.District;
        LocalNumber = address.LocalNumber;
        Complement = address.Complement;
        City = address.City;
        State = address.State;
        Country = address.Country;
    }

    public string PostalCode { get; private set; }
    public string Avenue { get; private set; }
    public string Street { get; private set; }
    public string District { get; private set; }
    public int LocalNumber { get; private set; }
    public int Complement { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
}

