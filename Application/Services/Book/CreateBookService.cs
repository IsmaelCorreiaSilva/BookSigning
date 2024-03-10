
using Application.Interfaces.Book;
using Application.Models.Book;
using Core.Interfaces.Book;

namespace Application.Services.Book
{
    public class CreateBookService : ICreateBookService
    {
        private readonly ICreateBookRepository repository;

        public CreateBookService(Core.Interfaces.Book.ICreateBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> CreateBookAsync(BookCreateModel createBook)
        {
            var book = createBook.ToEntity();
            return await repository.CreateBookAsync(book);
        }
    }
}
