

using Core.Interfaces.MonthlyShipping;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class SearchMonthlyShippingRepository : ISearchMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public SearchMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }
        public Task<IEnumerable<Core.Entities.MonthlyShipping>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.MonthlyShipping> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
