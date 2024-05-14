

using Core.Interfaces.Subscriber;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class SearchSubscriberRepository : ISearchSubscriberRepository
    {
        private readonly IDbContext context;

        public SearchSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Core.Entities.Subscriber>> GetAllAsync()
        {
            var sql = "SELECT * FROM Subscriber";
            using var connection = context.CreateConnection();
            return await connection.QueryAsync<Core.Entities.Subscriber>(sql);
        }

        public async Task<Core.Entities.Subscriber> GetByEmailAsync(string email)
        {
            var sql = "SELECT * FROM Subscriber WHERE sbs_email = @email";
            var parameters = new
            {
                email
            };
            using var connection = context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Core.Entities.Subscriber>(sql, parameters);
        }

        public async Task<Core.Entities.Subscriber> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Subscriber WHERE sbs_id = @id";
            var parameters = new
            {
                id
            };
            using var connection = context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Core.Entities.Subscriber>(sql, parameters);
        }
    }
}
