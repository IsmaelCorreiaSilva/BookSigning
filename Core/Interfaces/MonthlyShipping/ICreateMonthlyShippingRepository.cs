

namespace Core.Interfaces.MonthlyShipping
{
    public interface ICreateMonthlyShippingRepository
    {
        Task<int> CreateMonthlyShippingAsync(Entities.MonthlyShipping monthlyShipping);
    }
}
