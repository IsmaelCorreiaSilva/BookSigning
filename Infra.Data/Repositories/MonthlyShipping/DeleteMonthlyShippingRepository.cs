
using Core.Interfaces.MonthlyShipping;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class DeleteMonthlyShippingRepository : IDeleteMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public DeleteMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }
        public Task<int> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
