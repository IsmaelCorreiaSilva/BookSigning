
using Application.Models.Subscriber;

namespace Application.Interfaces.Subscriber
{
    public interface ICreateSubscriberService
    {
        Task<int> CreateSubscriberAsync(SubscriberCreateModel createSubscriber);
    }
}
