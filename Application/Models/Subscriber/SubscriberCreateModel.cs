using Application.Models.Address;

namespace Application.Models.Subscriber
{
    public class SubscriberCreateModel
    {
        public SubscriberCreateModel()
        {
            
        }
        public SubscriberCreateModel(string name, string email, string phone, AddressViewModel address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }

        public Core.Entities.Subscriber ToEntity()
            => new(Name, Email, Phone, Address.ToEntity());

    }
}
