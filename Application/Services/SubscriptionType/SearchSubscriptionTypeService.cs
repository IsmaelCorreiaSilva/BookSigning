
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
        public async Task<IEnumerable<SubscriptionTypeViewModel>> GetAllAsync()
        {
            var listSubscriptionType = await searchSubscriptionTypeRepository.GetAllAsync();
            return SubscriptionTypeViewModel.ListEntityFromListViewModel(listSubscriptionType);
        }

        public async Task<SubscriptionTypeViewModel> GetByIdAsync(int id)
        {
            var subscriptionType = await searchSubscriptionTypeRepository.GetByIdAsync(id);
            return SubscriptionTypeViewModel.FormEntity(subscriptionType);
        }
    }
}
