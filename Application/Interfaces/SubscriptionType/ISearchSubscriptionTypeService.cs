
using Application.Models.SubscriptionType;

namespace Application.Interfaces.SubscriptionType
{
    public interface ISearchSubscriptionTypeService
    {
        Task<IEnumerable<SubscriptionTypeViewModel>> GetAllAsync();
        Task<SubscriptionTypeViewModel> GetByIdAsync(int id);
    }
}
