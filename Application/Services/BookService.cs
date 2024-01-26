
using Application.Interfaces;
using Application.Models.Book;
using Core.Interfaces;

namespace Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Task<int> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookViewModel>> GetAll()
        {
            var books = await bookRepository.GetAll();
            return BookViewModel.ListFromEntity(books);
        }

        public async Task<BookViewModel> GetById(int id)
        {
            var book = await bookRepository.GetById(id);
            return BookViewModel.FromEntity(book);
        }

        public Task<int> Insert(BookCreateModel createBook)
        {
            var book = createBook.ToEntity();
           return  bookRepository.Insert(book);
        }

        public Task<int> Update(BookUpdateModel updateBook)
        {
            var book = updateBook.ToEntity();
            return bookRepository.Update(book);
        }
    }
}
