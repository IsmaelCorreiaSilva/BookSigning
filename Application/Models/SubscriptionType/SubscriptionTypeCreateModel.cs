﻿
namespace Application.Models.SubscriptionType
{
    public class SubscriptionTypeCreateModel
    {
        public SubscriptionTypeCreateModel(string title, string description, decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Core.Entities.SubscriptionType ToEntity()
            => new(Title,Description, Price);
    }
}
