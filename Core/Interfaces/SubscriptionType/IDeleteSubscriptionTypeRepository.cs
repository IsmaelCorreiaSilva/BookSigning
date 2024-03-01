
namespace Core.Interfaces.SubscriptionType
{
    public interface IDeleteSubscriptionTypeRepository
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
