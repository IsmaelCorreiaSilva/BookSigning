
using Application.Interfaces.SubscriptionType;
using Application.Models.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class UptadeSubscriptionTypeService : IUpdateSubscriptionTypeService
    {
        private readonly IUpdateSubscriptionTypeRepository repositoryUpdate;
        private readonly ISearchSubscriptionTypeRepository repositorySearch;

        public UptadeSubscriptionTypeService(IUpdateSubscriptionTypeRepository repositoryUpdate, ISearchSubscriptionTypeRepository repositorySearch)
        {
            this.repositoryUpdate = repositoryUpdate;
            this.repositorySearch = repositorySearch;
        }
        public async Task<int> UpdateSubscriptionTypeAsync(SubscriptionTypeUpdateModel updateSubscriptionType)
        {
            if (updateSubscriptionType == null)
                throw new Exception("Subscription Type is null");

            var subscriptionType = updateSubscriptionType.ToEntity();

            if (!subscriptionType.PriceGreaterThanZero())
                throw new Exception("Price is less than zero");

            var subscriptionTyperSearch = await repositorySearch.GetByIdAsync(subscriptionType.Id);

            if (subscriptionTyperSearch == null)
                throw new Exception("Subscription Type does not exist");

            return await repositoryUpdate.UpdateSubscriptionTypeAsync(subscriptionType);
        }
    }
}
