using Application.Interfaces.SubscriptionType;
using Application.Models.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class CreateSubscriptionTypeService : ICreateSubscriptionTypeService
    {
        private readonly ICreateSubscriptionTypeRepository repository;

        public CreateSubscriptionTypeService(ICreateSubscriptionTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateSubscriptionTypeAsync(SubscriptionTypeCreateModel createSubscriptionType)
        {

            if (createSubscriptionType == null)
                throw new Exception("Subscription Type is null");

            var subscriptionType = createSubscriptionType.ToEntity();

            if (!subscriptionType.PriceGreaterThanZero())
                throw new Exception("Price is less than zero");

            return await repository.CreateSubscriptionTypeAsync(subscriptionType);
        }
    }
}

