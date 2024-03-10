
using Core.Interfaces.Book;
using Infra.Data.Context;
using Dapper;

namespace Infra.Data.Repositories.Book
{
   
    public class UpdateBookRepository : IUpdateBookRepository
    {
        private readonly IDbContext context;

        public UpdateBookRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> UpdateBookAsync(Core.Entities.Book book)
        {
            var sql = "UPDATE Books SET boo_title = @Title, boo_summary = @Summary, boo_publishingCompany = @PublishingCompany, boo_author = @Author, boo_releaseDate = @ReleaseDate WHERE boo_id = @Id";
            var parameters = new
            {
                book.Id,
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
