
using Application.Interfaces.MonthlyShipping;
using Application.Models.Book;
using Application.Models.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class CreateMonthlyShippingService : ICreateMonthlyShippingService
    {
        private readonly ICreateMonthlyShippingRepository repositoryMonthlyShipping;

        public CreateMonthlyShippingService(ICreateMonthlyShippingRepository repositoryMonthlyShipping
            )
        {
            this.repositoryMonthlyShipping = repositoryMonthlyShipping;
        }
        public Task<int> CreateMonthlyShippingAsync(MonthlyShippingCreateModel createMonthlyShipping)
        {
            if (createMonthlyShipping == null)
                throw new Exception("Monthly Shipping is null");
            
            var monthlyShipping = createMonthlyShipping.ToEntity();

            if (!monthlyShipping.OwnsOneOrMoreBook())
                throw new Exception("Doesn't have books");

            return repositoryMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping);
        }
        private void LoadingBooks(ICollection<BookItemModel> books)
        {

        }
    }
}
