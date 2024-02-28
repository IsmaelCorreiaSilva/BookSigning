
using Core.Interfaces.SubscriptionType;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubscriptionType
{
    public class CreateSubscriptionTypeRepository : ICreateSubscriptionTypeRepository
    {
        private readonly IDbContext context;
        public CreateSubscriptionTypeRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateSubscriptionTypeAsync(Core.Entities.SubscriptionType subscriptionType)
        {
            var sql = "INSERT INTO SubscriptioType (sub_title, sub_description, sub_price) VALUES (@Title,@Description, @Price)";
            var parameters = new
            {
                subscriptionType.Title,
                subscriptionType.Price,
                subscriptionType.Description
            };

            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
