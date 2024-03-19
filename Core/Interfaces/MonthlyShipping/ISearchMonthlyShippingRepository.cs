

namespace Core.Interfaces.MonthlyShipping
{
    public interface ISearchMonthlyShippingRepository
    {
        Task<IEnumerable<Entities.MonthlyShipping>> GetAllAsync();
        Task<Entities.MonthlyShipping> GetByIdAsync(int id);
    }
}
