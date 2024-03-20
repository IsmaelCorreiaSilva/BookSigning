
namespace Core.Interfaces.Subscriber
{
    public interface IUpdateSubscriberRepository
    {
        Task<int> UpdateSubscriberAsync(Entities.Subscriber subscriber);
    }
}
