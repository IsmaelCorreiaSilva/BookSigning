
using Core.Interfaces.MonthlyShipping;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.MonthlyShipping
{
    public class SearchMonthlyShippingRepository : ISearchMonthlyShippingRepository
    {
        private readonly IDbContext context;

        public SearchMonthlyShippingRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Core.Entities.MonthlyShipping>> GetAllAsync()
        {
            var sql = "SELECT * FROM MonthlyShipping";
            using var connection = context.CreateConnection();
            return await connection.QueryAsync<Core.Entities.MonthlyShipping>(sql);
        }

        public async Task<Core.Entities.MonthlyShipping> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM MonthlyShipping mon_id = @id";
            var parameters = new
            {
                id
            };

            using var connection = context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Core.Entities.MonthlyShipping>(sql,parameters);
        }
    }
}
