
using Application.Interfaces.Subscriber;
using Application.Models.Subscriber;
using Core.Interfaces.Subscriber;

namespace Application.Services.Subscriber
{
    public class CreateSubscriberService : ICreateSubscriberService
    {
        private readonly ICreateSubscriberRepository repository;

        public CreateSubscriberService(ICreateSubscriberRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateSubscriberAsync(SubscriberCreateModel createSubscriber)
        {
            if (createSubscriber == null)
                throw new Exception("Subscriber is null");

            var subscriber = createSubscriber.ToEntity();
            
            return await repository.CreateSubscriberAsync(subscriber);
        }
    }
}
