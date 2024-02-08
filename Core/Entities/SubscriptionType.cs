
namespace Core.Entities
{
    public class SubscriptionType
    {
        public SubscriptionType(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
