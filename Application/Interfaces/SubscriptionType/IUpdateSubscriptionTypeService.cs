
using Application.Models.SubscriptionType;

namespace Application.Interfaces.SubscriptionType
{
    public interface IUpdateSubscriptionTypeService
    {
        Task<int> UpdateSubscriptionTypeAsync(SubscriptionTypeUpdateModel updateSubscriptionType);
    }
}
