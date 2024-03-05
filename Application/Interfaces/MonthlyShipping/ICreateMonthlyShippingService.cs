
using Application.Models.MonthlyShipping;

namespace Application.Interfaces.MonthlyShipping
{
    public interface ICreateMonthlyShippingService
    {
        Task<int> CreateMonthlyShippingAsync(MonthlyShippingCreateModel createMonthlyShipping);
    }
}
