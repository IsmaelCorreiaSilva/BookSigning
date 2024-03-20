
namespace Core.Interfaces.Subscriber
{
    public interface ICreateSubscriberRepository
    {
        Task<int> CreateSubscriberAsync(Entities.Subscriber subscriber);
    }
}
