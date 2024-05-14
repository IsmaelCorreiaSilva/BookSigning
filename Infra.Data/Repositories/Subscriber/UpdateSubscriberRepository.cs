
using Core.Entities;
using Core.Interfaces.Subscriber;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class UpdateSubscriberRepository : IUpdateSubscriberRepository
    {
        private readonly IDbContext context;

        public UpdateSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<int> UpdateSubscriberAsync(Core.Entities.Subscriber subscriber)
        {
            var sql = "UPDATE Subscriber SET sbs_name = @Name, sbs_email = @Email, sbs_phone = @Phone WHERE sbs_id = @Id";
            var parameters = new
            {
                subscriber.Id,
                subscriber.Name,
                subscriber.Email,
                subscriber.Phone
            };
            using var connection = context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }
}
