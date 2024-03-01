
namespace Application.Interfaces.SubscriptionType
{
    public interface IDeleteSubscriptionTypeService
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
