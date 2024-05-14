
using Core.Entities;
using Core.Interfaces.MonthlyShipping;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class UpdateMonthlyShippingRepository : IUpdateMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public UpdateMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<int> UpdateMonthlyShippingAsync(Core.Entities.MonthlyShipping monthlyShipping)
        {
            var sql = "UPDATE MonthlyShipping SET mon_description = @Description, mon_gift = @Gift WHERE mon_id = @Id";
            var parameters = new
            {
                monthlyShipping.Id,
                monthlyShipping.Description,
                monthlyShipping.Gift
            };
            using var connection = context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }
}
