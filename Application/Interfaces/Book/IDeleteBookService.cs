
namespace Application.Interfaces.Book
{
    public interface IDeleteBookService
    {
        Task<int> DeleteByIdAsync(int id);
    }
}
