using Application.Interfaces.Book;
using Application.Models.Book;
using Core.Interfaces.Book;

namespace Application.Services.Book
{
    public class SearchBookService : ISearchBookService
    {
        private readonly ISearchBookRepository repository;

        public SearchBookService(ISearchBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var books = await repository.GetAllAsync();
            return BookViewModel.EntityListForViewModelList(books);
        }

        public async Task<BookViewModel> GetByIdAsync(int id)
        {
            var book = await repository.GetByIdAsync(id);
            return BookViewModel.FromEntity(book);
        }
    }
}
