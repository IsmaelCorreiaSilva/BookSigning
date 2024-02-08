
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICreateSubscriptionTypeRepository
    {
        Task<int> CreateSubscriptionAsync(SubscriptionType subscriptionTpe);
    }
}
