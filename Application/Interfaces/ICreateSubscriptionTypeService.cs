using Application.Models.SubscriptionType;

namespace Application.Interfaces
{
    public interface ICreateSubscriptionTypeService
    {
        Task<int> CreateSubscriptionAsync(SubscriptionTypeCreateModel  createSubscriptionTpe);
    }
}
