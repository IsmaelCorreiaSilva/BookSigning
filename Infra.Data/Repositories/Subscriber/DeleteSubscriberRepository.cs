
using Core.Interfaces.Subscriber;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class DeleteSubscriberRepository : IDeleteSubscriberRepository
    {
        private readonly IDbContext context;

        public DeleteSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }
        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
