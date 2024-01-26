
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
            var sql = "DELETE FROM Books WHERE Id = @id";
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
            var sql = "SELECT * FROM Books WHERE Id = @id";
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
            var sql = "INSERT INTO Books (Title, Summary, PublishingCompany, Author, ReleaseDate) VALUES(@Title, @Summary, @PublishingCompany, @Author, @ReleaseDate)";
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
            var sql = "UPDATE Books SET Title = @Title, Summary = @Summary, PublishingCompany = @PublishingCompany, Author = @Author, ReleaseDate = @ReleaseDate WHERE Id = @Id";
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
