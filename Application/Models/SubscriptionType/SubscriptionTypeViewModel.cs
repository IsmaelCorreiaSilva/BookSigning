
namespace Application.Models.SubscriptionType
{
    public class SubscriptionTypeViewModel
    {
        public SubscriptionTypeViewModel(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public static SubscriptionTypeViewModel FormEntity(Core.Entities.SubscriptionType subscription) 
            => new(subscription.Title,subscription.Description,subscription.Price);
    }
}
