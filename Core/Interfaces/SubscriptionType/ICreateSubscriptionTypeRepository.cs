
namespace Core.Interfaces.SubscriptionType
{
    public interface ICreateSubscriptionTypeRepository
    {
        Task<int> CreateSubscriptionTypeAsync(Entities.SubscriptionType subscriptionTpe);
    }
}
