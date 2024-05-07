
using Core.Entities;
using Core.Interfaces.Subscriber;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Subscriber
{
    public class CreateSubscriberRepository : ICreateSubscriberRepository
    {
        private readonly IDbContext context;

        public CreateSubscriberRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateSubscriberAsync(Core.Entities.Subscriber subscriber)
        {
            var sql = "INSERT INTO Subscriber (sbs_name, sbs_email, sbs_phone) VALUES (@Name,@Email, @Phone)";
            var parameters = new
            {
                subscriber.Name,
                subscriber.Email,
                subscriber.Phone
            };

            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
