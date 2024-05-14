using Application.Interfaces.Subscriber;
using Application.Models.Subscriber;
using Core.Interfaces.Subscriber;

namespace Application.Services.Subscriber
{
    public class SearchSubscriberService : ISearchSubscriberService
    {
        private readonly ISearchSubscriberRepository searchSubscriberRepository;

        public SearchSubscriberService(ISearchSubscriberRepository searchSubscriberRepository)
        {
            this.searchSubscriberRepository = searchSubscriberRepository;
        }
        public async Task<IEnumerable<SubscriberViewModel>> GetAllAsync()
        {
            var listSubscriber = await  searchSubscriberRepository.GetAllAsync();
            return SubscriberViewModel.ListEntittyFromListViewModel(listSubscriber);
        }

        public async Task<SubscriberViewModel> GetByIdAsync(int id)
        {
            var subscriber = await searchSubscriberRepository.GetByIdAsync(id);
            return SubscriberViewModel.FromEntity(subscriber);
        }
    }
}
