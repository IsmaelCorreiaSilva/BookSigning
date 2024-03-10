

using Application.Interfaces.Book;
using Core.Interfaces.Book;

namespace Application.Services.Book
{
    public class DeleteBookService : IDeleteBookService
    {
        private readonly IDeleteBookRepository repository;

        public DeleteBookService(IDeleteBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> DeleteByIdAsync(int id)
        {
            return await repository.DeleteByIdAsync(id);
        }
    }
}
