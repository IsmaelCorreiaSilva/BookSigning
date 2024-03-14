

using Application.Interfaces.MonthlyShipping;
using Application.Models.Book;
using Application.Models.MonthlyShipping;
using Core.Interfaces.Book;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class UpdateMonthlyShippingService : IUpdateMonthlyShippingService
    {
        private readonly IUpdateMonthlyShippingRepository repositoryMonthlyShipping;
        private readonly ISearchBookRepository repositorySearchBook;

        public UpdateMonthlyShippingService(IUpdateMonthlyShippingRepository repositoryMonthlyShipping,
                        ISearchBookRepository repositorySearchBook)
        {
            this.repositoryMonthlyShipping = repositoryMonthlyShipping;
            this.repositorySearchBook = repositorySearchBook;
        }


        public async Task<int> UpdateMonthlyShippingAsync(MonthlyShippingUpdateModel updateMonthlyShipping)
        {
            if (updateMonthlyShipping == null)
                throw new Exception("Monthly Shipping is null");

            if (updateMonthlyShipping.Id < 1)
                throw new Exception("Id is invalid");

            var monthlyShipping = updateMonthlyShipping.ToEntity();
            var books = await LoadingBooks(updateMonthlyShipping.Books);
            monthlyShipping.AddBook(books);

            if (!monthlyShipping.OwnsOneOrMoreBook())
                throw new Exception("Doesn't have books");

            return await repositoryMonthlyShipping.UpdateMonthlyShippingAsync(monthlyShipping);
        }
        private async Task<ICollection<Core.Entities.Book>> LoadingBooks(ICollection<BookItemModel> books)
        {
            List<Core.Entities.Book> listBook = new List<Core.Entities.Book>();

            foreach (var item in books)
            {
                var bookSearch = await repositorySearchBook.GetByIdAsync(item.Id);
                listBook.Add(bookSearch);
            }

            return listBook;
        }
    }
}
