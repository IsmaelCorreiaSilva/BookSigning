
using Application.Interfaces.MonthlyShipping;
using Application.Models.MonthlyShipping;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class CreateMonthlyShippingService : ICreateMonthlyShippingService
    {
        private readonly ICreateMonthlyShippingRepository repository;

        public CreateMonthlyShippingService(ICreateMonthlyShippingRepository repository)
        {
            this.repository = repository;
        }
        public Task<int> CreateMonthlyShippingAsync(MonthlyShippingCreateModel createMonthlyShipping)
        {
            return repository.CreateMonthlyShippingAsync(createMonthlyShipping.ToEntity());
        }
    }
}
