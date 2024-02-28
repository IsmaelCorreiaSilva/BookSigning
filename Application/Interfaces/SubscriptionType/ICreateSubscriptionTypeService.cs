using Application.Models.SubscriptionType;

namespace Application.Interfaces.SubscriptionType
{
    public interface ICreateSubscriptionTypeService
    {
        Task<int> CreateSubscriptionTypeAsync(SubscriptionTypeCreateModel createSubscriptionTpe);
    }
}
