
using Application.Interfaces.SubscriptionType;
using Application.Models.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class UptadeSubscriptionTypeService : IUpdateSubscriptionTypeService
    {
        private readonly IUpdateSubscriptionTypeRepository repository;

        public UptadeSubscriptionTypeService(IUpdateSubscriptionTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> UpdateSubscriptionTypeAsync(SubscriptionTypeUpdateModel updateSubscriptionType)
        {
            if (updateSubscriptionType == null)
                throw new Exception("Subscription Type is null");

            var subscriptionType = updateSubscriptionType.ToEntity();

            if (!subscriptionType.PriceGreaterThanZero())
                throw new Exception("Price is less than zero");
            
            return await repository.UpdateSubscriptionTypeAsync(subscriptionType);
        }
    }
}
