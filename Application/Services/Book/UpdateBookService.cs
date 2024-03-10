

using Application.Interfaces.Book;
using Application.Models.Book;
using Core.Interfaces.Book;

namespace Application.Services.Book
{
    public class UpdateBookService : IUpdateBookService
    {
        private readonly IUpdateBookRepository repository;

        public UpdateBookService(IUpdateBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> UpdateBookAsync(BookUpdateModel updateBook)
        {
            var book = updateBook.ToEntity();
            return await repository.UpdateBookAsync(book);
        }
    }
}
