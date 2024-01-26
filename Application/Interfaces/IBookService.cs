using Application.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookViewModel>> GetAll();
        Task<BookViewModel> GetById(int id);
        Task<int> DeleteById(int id);
        Task<int> Insert(BookCreateModel book);
        Task<int> Update(BookUpdateModel book);
    }
}
