
namespace Core.Interfaces.Book
{
    public interface ISearchBookRepository
    {
        Task<IEnumerable<Entities.Book>> GetAllAsync();
        Task<Entities.Book> GetByIdAsync(int id);
    }
}
