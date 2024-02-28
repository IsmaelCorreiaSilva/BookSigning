
namespace Core.Interfaces.SubscriptionType
{
    public interface IUpdateSubscriptionTypeRepository
    {
        Task<int> UpdateSubscriptionTypeAsync(Entities.SubscriptionType subscriptionTpe);
    }
}
