

using Core.Interfaces.Book;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories.Book
{
    public class CreateBookRepository : ICreateBookRepository
    {
        private readonly IDbContext context;

        public CreateBookRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateBookAsync(Core.Entities.Book book)
        {
            var sql = "INSERT INTO Books (boo_title, boo_summary, boo_publishingCompany, boo_author, boo_ReleaseDate) VALUES(@Title, @Summary, @PublishingCompany, @Author, @ReleaseDate)";
            var parameters = new
            {
                book.Title,
                book.Summary,
                book.PublishingCompany,
                book.Author,
                book.ReleaseDate
            };

            using var connection = context.CreateConnection();
            var result = await connection.ExecuteAsync(sql, parameters);
            return result;
        }
    }
}
