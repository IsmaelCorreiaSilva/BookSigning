
using Application.Interfaces.Subscriber;
using Application.Models.Subscriber;
using Core.Interfaces.Subscriber;

namespace Application.Services.Subscriber
{
    public class UpdateSubscriberService:IUpdateSubscriberService
    {
        private readonly IUpdateSubscriberRepository updateSubscriberRepository;
        private readonly ISearchSubscriberRepository searchSubscriberRepository;

        public UpdateSubscriberService(IUpdateSubscriberRepository updateSubscriberRepository,
                                        ISearchSubscriberRepository searchSubscriberRepository)
        {
            this.updateSubscriberRepository = updateSubscriberRepository;
            this.searchSubscriberRepository = searchSubscriberRepository;
        }

        public async Task<int> UpdateSubscriberAsync(SubscriberUpdateModel updateSubscriber)
        {
            if (updateSubscriber == null)
                throw new Exception("Subscriber is null");

            var subscriber = updateSubscriber.ToEntity();

            var searchingSubscriber = await searchSubscriberRepository.GetByEmailAsync(subscriber.Email);

            if (searchingSubscriber != null)
                throw new Exception("Email is already being used");

            return await updateSubscriberRepository.UpdateSubscriberAsync(subscriber);
        }
    }
}
