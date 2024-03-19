
namespace Application.Interfaces.MonthlyShipping
{
    public interface IDeleteMonthlyShippingService
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
