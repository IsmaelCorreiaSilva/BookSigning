
using Core.Interfaces.MonthlyShipping;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class DeleteMonthlyShippingRepository : IDeleteMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public DeleteMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            var sql = "DELETE FROM MonthlyShipping WHERE mon_id = @id";
            var parameters = new
            {
               id
            };

            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
