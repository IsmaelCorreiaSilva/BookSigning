
using Core.Interfaces.Subscriber;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class UpdateSubscriberRepository : IUpdateSubscriberRepository
    {
        private readonly IDbContext context;

        public UpdateSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }

        public Task<int> UpdateSubscriberAsync(Core.Entities.Subscriber subscriber)
        {
            throw new NotImplementedException();
        }
    }
}
