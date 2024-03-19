

namespace Core.Interfaces.MonthlyShipping
{
    public interface IDeleteMonthlyShippingRepository
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
