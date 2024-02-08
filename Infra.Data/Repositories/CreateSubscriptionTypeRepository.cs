
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class CreateSubscriptionTypeRepository : ICreateSubscriptionTypeRepository
    {
        private readonly IDbContext context;
        public CreateSubscriptionTypeRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateSubscriptionAsync(SubscriptionType subscriptionTpe)
        {
            var sql = "INSERT INTO SubscriptionType (sub_title, sub_description, sub_price) VALUES(@Title,@Description, @Price)";
            var parameters = new
            {
                subscriptionTpe.Price,
                subscriptionTpe.Description,
            };

            using var connection = context.CreateConnection();
            var result = await connection.ExecuteAsync(sql,parameters);
            return result;
        }
    }
}
