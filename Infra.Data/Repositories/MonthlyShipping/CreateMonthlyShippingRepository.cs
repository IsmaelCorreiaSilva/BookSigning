

using Core.Entities;
using Core.Interfaces.MonthlyShipping;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class CreateMonthlyShippingRepository : ICreateMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public CreateMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateMonthlyShippingAsync(Core.Entities.MonthlyShipping monthlyShipping)
        {
            var sql = "INSERT INTO MonthlyShipping (mon_description, mon_gift) VALUES (@description,@gift)";
            var parameters = new
            {
                monthlyShipping.Description,
                monthlyShipping.Gift
            };

            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
