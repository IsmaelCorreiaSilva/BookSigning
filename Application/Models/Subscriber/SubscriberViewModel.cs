using Application.Models.Address;

namespace Application.Models.Subscriber
{
    public class SubscriberViewModel
    {
        public SubscriberViewModel(int id, string name, string email, string phone, AddressViewModel address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressViewModel Address { get; set; }

        public static SubscriberViewModel FromEntity(Core.Entities.Subscriber subscriber)
            => new(subscriber.Id, subscriber.Name, subscriber.Email, subscriber.Phone, AddressViewModel.FromEntity(subscriber.Address));

        public static IEnumerable<SubscriberViewModel> ListEntittyFromListViewModel(IEnumerable<Core.Entities.Subscriber> subscriberes)
        { 
            var listSubscriber = new List<SubscriberViewModel>();
            foreach (var item in subscriberes)
            {
                listSubscriber.Add(FromEntity(item));
            }
            return listSubscriber;
        }
    }
}
