

namespace Core.Interfaces.Book
{
    public interface IUpdateBookRepository
    {
        Task<int> UpdateBookAsync(Entities.Book book);
    }
}
