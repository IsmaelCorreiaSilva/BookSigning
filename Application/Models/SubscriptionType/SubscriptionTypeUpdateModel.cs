﻿
namespace Application.Models.SubscriptionType
{
    public class SubscriptionTypeUpdateModel
    {
        public SubscriptionTypeUpdateModel(int id, string title, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Core.Entities.SubscriptionType ToEntity()
            => new(Id, Title, Description, Price);
    }
}
