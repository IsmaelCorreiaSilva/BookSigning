
using Core.Interfaces.Subscriber;

namespace Application.Services.Subscriber
{
    public class DeleteSubscriberService
    {
        private readonly IDeleteSubscriberRepository deleteSubscriberRepository;
        private readonly ISearchSubscriberRepository searchSubscriberRepository;

        public DeleteSubscriberService(IDeleteSubscriberRepository deleteSubscriberRepository,
                                        ISearchSubscriberRepository searchSubscriberRepository)
        {
            this.deleteSubscriberRepository = deleteSubscriberRepository;
            this.searchSubscriberRepository = searchSubscriberRepository;
        }
        public async Task<int> DeleteByIdAsync(int id) 
        {
            if (id < 0)
                throw new Exception("Invalid ID");

            var subscriberSearching = await searchSubscriberRepository.GetByIdAsync(id);

            if (subscriberSearching == null)
                throw new Exception("Subscriber does not exist");

            return await deleteSubscriberRepository.DeleteByIdAsync(id);
        }
    }
}
