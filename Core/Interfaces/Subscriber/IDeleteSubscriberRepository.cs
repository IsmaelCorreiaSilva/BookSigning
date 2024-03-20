
namespace Core.Interfaces.Subscriber
{
    public interface IDeleteSubscriberRepository
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
