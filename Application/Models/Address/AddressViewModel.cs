
namespace Application.Models.Address
{
    public class AddressViewModel
    {
        public AddressViewModel() { }
        public AddressViewModel(string zipCode, string city, string street, string number, string complement, string discrict) 
        {
            ZipCode = zipCode;
            City = city;
            Street = street;
            Number = number;
            Complement = complement;
            District = discrict;
        }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }

        public Core.Entities.Address ToEntity()
            => new(ZipCode, City, Street, Number, Complement, District);
        public static AddressViewModel FromEntity(Core.Entities.Address address)
            => new(address.ZipCode, address.City, address.Street, address.Number, address.Complement, address.District);
    }
}
