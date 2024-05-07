
using Application.Models.Book;

namespace Application.Models.MonthlyShipping
{
    public class MonthlyShippingViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<BookItemModel> Books { get; set; }
        public string Gift { get; set; }
    }
}
