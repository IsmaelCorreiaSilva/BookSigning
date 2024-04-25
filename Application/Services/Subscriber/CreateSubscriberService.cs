
using Application.Interfaces.Subscriber;
using Application.Models.Subscriber;
using Core.Interfaces.Subscriber;

namespace Application.Services.Subscriber
{
    public class CreateSubscriberService : ICreateSubscriberService
    {
        private readonly ICreateSubscriberRepository createSubscriberRepository;
        private readonly ISearchSubscriberRepository searchSubscriberRepository;

        public CreateSubscriberService(ICreateSubscriberRepository createSubscriberRepository, 
            ISearchSubscriberRepository searchSubscriberRepository)
        {
            this.createSubscriberRepository = createSubscriberRepository;
            this.searchSubscriberRepository = searchSubscriberRepository;
        }

        public async Task<int> CreateSubscriberAsync(SubscriberCreateModel createSubscriber)
        {
            if (createSubscriber == null)
                throw new Exception("Subscriber is null");

            var subscriber = createSubscriber.ToEntity();

            var searchSingleEmail = await searchSubscriberRepository.GetByEmailAsync(subscriber.Email);

            if (searchSingleEmail != null)
                throw new Exception("Email is already being used");
            
            return await createSubscriberRepository.CreateSubscriberAsync(subscriber);
        }
    }
}
 