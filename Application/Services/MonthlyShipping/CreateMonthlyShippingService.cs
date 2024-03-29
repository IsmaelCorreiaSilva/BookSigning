﻿
using Application.Interfaces.MonthlyShipping;
using Application.Models.Book;
using Application.Models.MonthlyShipping;
using Core.Interfaces.Book;
using Core.Interfaces.MonthlyShipping;

namespace Application.Services.MonthlyShipping
{
    public class CreateMonthlyShippingService : ICreateMonthlyShippingService
    {
        private readonly ICreateMonthlyShippingRepository repositoryMonthlyShipping;
        private readonly ISearchBookRepository repositorySearchBook;

        public CreateMonthlyShippingService(ICreateMonthlyShippingRepository repositoryMonthlyShipping,
            ISearchBookRepository repositorySearchBook)
        {
            this.repositoryMonthlyShipping = repositoryMonthlyShipping;
            this.repositorySearchBook = repositorySearchBook;
        }
        public async Task<int> CreateMonthlyShippingAsync(MonthlyShippingCreateModel createMonthlyShipping)
        {
            if (createMonthlyShipping == null)
                throw new Exception("Monthly Shipping is null");
            
            var monthlyShipping = createMonthlyShipping.ToEntity();
            var books = await LoadingBooks(createMonthlyShipping.Books); 
            monthlyShipping.AddBook(books);

            if (!monthlyShipping.OwnsOneOrMoreBook())
                throw new Exception("Doesn't have books");

            return await repositoryMonthlyShipping.CreateMonthlyShippingAsync(monthlyShipping);
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
