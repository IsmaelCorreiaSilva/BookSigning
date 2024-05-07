

using Core.Interfaces.Subscriber;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class SearchSubscriberRepository : ISearchSubscriberRepository
    {
        private readonly IDbContext context;

        public SearchSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }
        public Task<IEnumerable<Core.Entities.Subscriber>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Subscriber> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Subscriber> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
