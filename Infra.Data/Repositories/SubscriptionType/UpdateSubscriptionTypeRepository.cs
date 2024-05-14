using Core.Interfaces.SubscriptionType;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubscriptionType
{
    public class UpdateSubscriptionTypeRepository : IUpdateSubscriptionTypeRepository
    {
        private readonly IDbContext context;

        public UpdateSubscriptionTypeRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<int> UpdateSubscriptionTypeAsync(Core.Entities.SubscriptionType subscriptionType)
        {
            var sql = "UPDATE SubscriptionType SET sub_title = @Title, sub_description = @Description, sub_price = @Price WHERE sub_id = @Id";
            var parameters = new
            {
                subscriptionType.Id,
                subscriptionType.Title,
                subscriptionType.Price,
                subscriptionType.Description
            };
            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
