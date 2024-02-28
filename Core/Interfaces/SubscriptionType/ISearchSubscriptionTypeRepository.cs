
namespace Core.Interfaces.SubscriptionType
{
    public interface ISearchSubscriptionTypeRepository
    {
        Task<IEnumerable<Entities.SubscriptionType>> GetAllAsync();
        Task<Entities.SubscriptionType> GetByIdAsync(int id);
    }
}
