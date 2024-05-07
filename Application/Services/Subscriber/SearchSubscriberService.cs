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
        public Task<IEnumerable<SubscriberViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubscriberViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
