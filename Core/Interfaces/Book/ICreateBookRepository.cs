
namespace Core.Interfaces.Book
{
    public interface ICreateBookRepository
    {
        Task<int> CreateBookAsync(Core.Entities.Book book);
    }
}
