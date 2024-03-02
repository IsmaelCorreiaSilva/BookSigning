﻿
using Core.Interfaces.SubscriptionType;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.SubscriptionType
{
    public class DeleteSubscriptionTypeRepository : IDeleteSubscriptionTypeRepository
    {
        private readonly IDbContext context;

        public DeleteSubscriptionTypeRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            var sql = "DELETE FROM SubscriptionType WHERE sub_id = @id";
            var parameters = new
            {
                id
            };
            using var connection = context.CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
