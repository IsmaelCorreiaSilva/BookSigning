

namespace Core.Interfaces.Subscriber
{
    public interface ISearchSubscriberRepository
    {
        Task<IEnumerable<Entities.Subscriber>> GetAllAsync();
        Task<Entities.Subscriber> GetByIdAsync(int id);
    }
}
