
using Application.Models.MonthlyShipping;

namespace Application.Interfaces.MonthlyShipping
{
    public interface IUpdateMonthlyShippingService
    {
        Task<int> UpdateMonthlyShippingAsync(MonthlyShippingUpdateModel updateMonthlyShipping);
    }
}
