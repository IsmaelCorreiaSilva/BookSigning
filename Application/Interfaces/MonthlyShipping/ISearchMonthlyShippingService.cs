
using Application.Models.MonthlyShipping;

namespace Application.Interfaces.MonthlyShipping
{
    public interface ISearchMonthlyShippingService
    {
        Task<IEnumerable<MonthlyShippingViewModel>> GetAllAsync();
        Task<MonthlyShippingViewModel> GetByIdAsync(int id);
    }
}
