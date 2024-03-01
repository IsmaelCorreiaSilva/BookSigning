
using Core.Interfaces.SubscriptionType;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubscriptionType
{
    public class SearchSubscriptionTypeRepository : ISearchSubscriptionTypeRepository
    {
        private readonly IDbContext context;

        public SearchSubscriptionTypeRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Core.Entities.SubscriptionType>> GetAllAsync()
        {
            var sql = "SELECT * FROM SubscriptionType";
            using var connection = context.CreateConnection();
            var result = await connection.QueryAsync<Core.Entities.SubscriptionType>(sql);
            return result;
        }

        public async Task<Core.Entities.SubscriptionType> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM SubscriptionType WHERE sub_id = @id";
            var parameters = new { id };
            using var connection = context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<Core.Entities.SubscriptionType>(sql,parameters);
            return result;
        }
    }
}
