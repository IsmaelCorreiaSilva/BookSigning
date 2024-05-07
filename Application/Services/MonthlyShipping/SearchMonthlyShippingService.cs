

using Application.Interfaces.MonthlyShipping;
using Application.Models.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class SearchMonthlyShippingService : ISearchMonthlyShippingService
    {
        private readonly ISearchMonthlyShippingRepository searchMonthlyShippingRepository;

        public SearchMonthlyShippingService(ISearchMonthlyShippingRepository searchMonthlyShippingRepository)
        {
            this.searchMonthlyShippingRepository = searchMonthlyShippingRepository;
        }
        public Task<IEnumerable<MonthlyShippingViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MonthlyShippingViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
