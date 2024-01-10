using BookSigning.Entities;
using Dapper;
using MySqlConnector;

namespace BookSigning.Data
{
    public class BookData
    {
        private readonly string connectionString;
        public BookData()
        {
            connectionString = "Server=localhost;database=BookSigning;Uid=root;Pwd=root; Port=3306";
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Books";
                var books = await sqlConnection.QueryAsync<Book>(sql);
                return books;
            }
        }
        public async Task<Book> GetById(int id)
        {
            var parameters = new {
                id
            };

            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Books WHERE Id = @id";
                var book = await sqlConnection.QueryFirstOrDefaultAsync<Book>(sql, parameters);
                return book;
            }
        }
        public async Task<int> DeleteById(int id)
        {
            var parameters = new
            {
                id
            };

            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "DELETE FROM Books WHERE Id = @id";
                var book = await sqlConnection.ExecuteAsync(sql, parameters);
                return book;
            }
        }
        public async Task<int> Insert(Book book)
        {
            var parameters = new { 
                book.Title,
                book.Summary,
                book.PublishingCompany,
                book.Author,
                book.ReleaseDate
            };

            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "INSERT INTO Books (Title, Summary, PublishingCompany, Author, ReleaseDate) VALUES(@Title, @Summary, @PublishingCompany, @Author, @ReleaseDate)";
                var result = await sqlConnection.ExecuteScalarAsync<int>(sql, parameters);
                return result;
            }
        }
        public async Task<Book> Update(int id, Book book)
        {
            var parameters = new
            {
                id,
                book.Title,
                book.Summary,
                book.PublishingCompany,
                book.Author,
                book.ReleaseDate
            };

            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                var sql = "UPDATE Books SET Title = @Title, Summary = @Summary, PublishingCompany = @PublishingCompany, Author = @Author, ReleaseDate = @ReleaseDate WHERE Id = @Id";
                var result = await sqlConnection.ExecuteScalarAsync<Book>(sql, parameters);
                return result;
            }
        }
    }
}
