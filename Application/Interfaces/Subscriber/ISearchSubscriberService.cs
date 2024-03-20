

using Application.Models.Subscriber;

namespace Application.Interfaces.Subscriber
{
    public interface ISearchSubscriberService
    {
        Task<IEnumerable<SubscriberViewModel>> GetAllAsync();
        Task<SubscriberViewModel> GetByIdAsync(int id);
    }
}
