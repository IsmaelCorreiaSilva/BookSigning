
using Application.Interfaces.SubscriptionType;
using Core.Interfaces.SubscriptionType;

namespace Application.Services.SubscriptionType
{
    public class DeleteSubscriptionTypeService : IDeleteSubscriptionTypeService
    {
        private readonly IDeleteSubscriptionTypeRepository repository;

        public DeleteSubscriptionTypeService(IDeleteSubscriptionTypeRepository repository)
        {
            this.repository = repository;
        }
        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
