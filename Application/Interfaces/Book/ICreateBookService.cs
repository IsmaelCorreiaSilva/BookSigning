using Application.Models.Book;

namespace Application.Interfaces.Book
{
    public interface ICreateBookService
    {
        Task<int> CreateBookAsync(BookCreateModel book);
    }
}
