
using Core.Entities;
using Core.Interfaces;
using Dapper;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContext context;

        public BookRepository(IDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteById(int id)
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

        public async Task<IEnumerable<Book>> GetAll()
        {
            var sql = "SELECT * FROM Books";
            using var connection = context.CreateConnection();
            var result = await connection.QueryAsync<Book>(sql);
            return result;
        }

        public async Task<Book> GetById(int id)
        {
            var sql = "SELECT * FROM Books WHERE boo_id = @id";
            var parameters = new
            {
                id
            };
            using var connection = context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<Book>(sql, parameters);
            return result;
        }

        public async Task<int> Insert(Book book)
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
            var result = await connection.ExecuteAsync(sql,parameters);
            return result;
        }

        public async Task<int> Update(Book book)
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
            var result = await connection.ExecuteAsync(sql,parameters);
            return result;
        }
    }
}
