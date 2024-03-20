
namespace Core.Entities
{
    public class Address
    {
        public Address() { }
        public Address(string zipCode, string city, string street, string number, string complement, string district)
        {
            ZipCode = zipCode;
            City = city;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;            
        }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set;}
        public string District { get; private set; }
    }
}
