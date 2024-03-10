
namespace Core.Interfaces.Book
{
    public interface IDeleteBookRepository
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
