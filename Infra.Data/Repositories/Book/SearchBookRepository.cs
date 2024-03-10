
using Core.Interfaces.Book;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Book
{
    public class SearchBookRepository : ISearchBookRepository
    {
        private readonly IDbContext context;

        public SearchBookRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Core.Entities.Book>> GetAllAsync()
        {
            var sql = "SELECT * FROM Books";
            using var connection = context.CreateConnection();
            var result = await connection.QueryAsync<Core.Entities.Book>(sql);
            return result;
        }

        public async Task<Core.Entities.Book> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Books WHERE boo_id = @id";
            var parameters = new
            {
                id
            };
            using var connection = context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<Core.Entities.Book>(sql, parameters);
            return result;
        }
    }
}
