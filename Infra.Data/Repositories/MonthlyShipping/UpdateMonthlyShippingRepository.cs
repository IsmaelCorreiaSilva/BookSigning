
using Core.Interfaces.MonthlyShipping;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class UpdateMonthlyShippingRepository : IUpdateMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public UpdateMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }

        public Task<int> UpdateMonthlyShippingAsync(Core.Entities.MonthlyShipping monthlyShipping)
        {
            throw new NotImplementedException();
        }
    }
}
