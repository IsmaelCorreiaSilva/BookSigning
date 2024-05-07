
using Application.Interfaces.SubscriptionType;
using Application.Models.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class SearchSubscriptionTypeService : ISearchSubscriptionTypeService
    {
        private readonly ISearchSubscriptionTypeRepository searchSubscriptionTypeRepository;

        public SearchSubscriptionTypeService(ISearchSubscriptionTypeRepository searchSubscriptionTypeRepository)
        {
            this.searchSubscriptionTypeRepository = searchSubscriptionTypeRepository;
        }
        public Task<IEnumerable<SubscriptionTypeViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubscriptionTypeViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
