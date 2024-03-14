
namespace Core.Interfaces.MonthlyShipping
{
    public interface IUpdateMonthlyShippingRepository
    {
        Task<int> UpdateMonthlyShippingAsync(Entities.MonthlyShipping monthlyShipping);
    }
}
