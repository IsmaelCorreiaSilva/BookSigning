
using Application.Models.Book;

namespace Application.Interfaces.Book
{
    public interface ISearchBookService
    {
        Task<IEnumerable<BookViewModel>> GetAllAsync();
        Task<BookViewModel> GetByIdAsync(int id);
    }
}
