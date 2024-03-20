using Application.Models.Address;

namespace Application.Models.Subscriber
{
    public class SubscriberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }

    }
}
