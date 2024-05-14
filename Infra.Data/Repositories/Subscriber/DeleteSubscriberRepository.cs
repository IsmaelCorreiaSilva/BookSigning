
using Core.Interfaces.Subscriber;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class DeleteSubscriberRepository : IDeleteSubscriberRepository
    {
        private readonly IDbContext context;

        public DeleteSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            var sql = "DELETE FROM Subscriber WHERE sbs_id = @id";
            var parameters = new
            {
                id
            };

            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
