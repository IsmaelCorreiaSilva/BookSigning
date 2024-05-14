

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
        public async Task<IEnumerable<MonthlyShippingViewModel>> GetAllAsync()
        {
            var listMonthlyShipping = await searchMonthlyShippingRepository.GetAllAsync();
            return MonthlyShippingViewModel.EntityListForViewModelList(listMonthlyShipping);
        }

        public async Task<MonthlyShippingViewModel> GetByIdAsync(int id)
        {
            var monthlyShipping = await searchMonthlyShippingRepository.GetByIdAsync(id);
            return MonthlyShippingViewModel.FromEntity(monthlyShipping);
        }
    }
}
