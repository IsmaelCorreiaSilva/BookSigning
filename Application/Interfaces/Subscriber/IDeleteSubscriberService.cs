
namespace Application.Interfaces.Subscriber
{
    public interface IDeleteSubscriberService
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
