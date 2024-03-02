
using Application.Interfaces.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class DeleteSubscriptionTypeService : IDeleteSubscriptionTypeService
    {
        private readonly IDeleteSubscriptionTypeRepository repositoryDelete;
        private readonly ISearchSubscriptionTypeRepository repositorySearch;

        public DeleteSubscriptionTypeService(IDeleteSubscriptionTypeRepository repositoryDelete,
            ISearchSubscriptionTypeRepository repositorySearch)
        {
            this.repositoryDelete = repositoryDelete;
            this.repositorySearch = repositorySearch;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            if(id < 0)
                throw new Exception("Invalid ID");

            var subscriptionType = await repositorySearch.GetByIdAsync(id);

            if (subscriptionType == null)
                throw new Exception("Subscription Type does not exist");

            return await repositoryDelete.DeleteByIdAsync(id);
        }
    }
}
