

using Core.Interfaces.Book;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Book
{
    public class DeleteBookRepository : IDeleteBookRepository
    {
        private readonly IDbContext context;

        public DeleteBookRepository(IDbContext context)
        {
            this.context = context;
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var sql = "DELETE FROM Books WHERE boo_id = @id";
            var parameters = new
            {
                id
            };
            using var connection = context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }
}
