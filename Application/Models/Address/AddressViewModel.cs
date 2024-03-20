
namespace Application.Models.Address
{
    public class AddressViewModel
    {
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }

        public Core.Entities.Address ToEntity()
            => new(ZipCode, City, Street, Number, Complement, District);
    }
}
