
using Application.Models.Address;

namespace Application.Models.Subscriber
{
    public class SubscriberUpdateModel
    {
        public SubscriberUpdateModel(int id, string name, string email, string phone, AddressViewModel address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }

        public Core.Entities.Subscriber ToEntity()
            => new(Id, Name, Email, Phone, Address.ToEntity());
    }
}
