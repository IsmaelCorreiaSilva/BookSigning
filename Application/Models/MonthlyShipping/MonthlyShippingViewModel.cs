
using Application.Models.Book;

namespace Application.Models.MonthlyShipping
{
    public class MonthlyShippingViewModel
    {
        public MonthlyShippingViewModel(int id, string description, IEnumerable<BookViewModel> books, string gift)
        {
            Id = id;
            Description = description;
            Books = books;
            Gift = gift;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<BookViewModel> Books { get; set; }
        public string Gift { get; set; }

        public static MonthlyShippingViewModel FromEntity(Core.Entities.MonthlyShipping monthlyShipping)
                => new(monthlyShipping.Id, monthlyShipping.Description, BookViewModel.EntityListForViewModelList(monthlyShipping.Books), monthlyShipping.Gift);
        public static IEnumerable<MonthlyShippingViewModel> EntityListForViewModelList(IEnumerable<Core.Entities.MonthlyShipping> list)
        {
            var listMonthlyShipping = new List<MonthlyShippingViewModel>();
            foreach (var item in list)
            {
                listMonthlyShipping.Add(FromEntity(item));
            }
            return listMonthlyShipping;
        }
    }
}
