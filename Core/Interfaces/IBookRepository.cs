
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<int> DeleteById(int id);
        Task<int> Insert(Book book);
        Task<int> Update(Book book);
    }
}
