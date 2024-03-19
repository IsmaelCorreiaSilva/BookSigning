

using Application.Interfaces.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class DeleteMonthlyShippingService : IDeleteMonthlyShippingService
    {
        private readonly IDeleteMonthlyShippingRepository repositoryMonthlyShipping;
        private readonly ISearchMonthlyShippingRepository repositorySearch;

        public DeleteMonthlyShippingService(IDeleteMonthlyShippingRepository repositoryMonthlyShipping,
            ISearchMonthlyShippingRepository repositorySearch)
        {
            this.repositoryMonthlyShipping = repositoryMonthlyShipping;
            this.repositorySearch = repositorySearch;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            if (id < 0)
                throw new Exception("Invalid ID");

            var monthlyShipping = await repositorySearch.GetByIdAsync(id);

            if (monthlyShipping == null)
                throw new Exception("Monthly Shipping does not exist");

            return await repositoryMonthlyShipping.DeleteByIdAsync(id);
        }
    }
}
