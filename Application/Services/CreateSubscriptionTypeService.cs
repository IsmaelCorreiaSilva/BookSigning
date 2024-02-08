using Application.Interfaces;
using Application.Models.SubscriptionType;
using Core.Interfaces;

namespace Application.Services
{
    public class CreateSubscriptionTypeService : ICreateSubscriptionTypeService
    {
        private readonly ICreateSubscriptionTypeRepository repository;

        public CreateSubscriptionTypeService(ICreateSubscriptionTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateSubscriptionAsync(SubscriptionTypeCreateModel createSubscriptionTpe)
        {
            var subscriptionType = createSubscriptionTpe.ToEntity();

            return await repository.CreateSubscriptionAsync(subscriptionType);
        }
    }
}
