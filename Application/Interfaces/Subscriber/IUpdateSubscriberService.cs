
using Application.Models.Subscriber;

namespace Application.Interfaces.Subscriber
{
    public interface IUpdateSubscriberService
    {
        Task<int> UpdateSubscriberAsync(SubscriberCreateModel updateSubscriber);
    }
}
