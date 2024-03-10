
using Application.Models.Book;

namespace Application.Interfaces.Book
{
    public interface IUpdateBookService
    {
        Task<int> UpdateBookAsync(BookUpdateModel book);
    }
}

