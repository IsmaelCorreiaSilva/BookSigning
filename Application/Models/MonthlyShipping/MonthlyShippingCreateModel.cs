
using Application.Models.Book;

namespace Application.Models.MonthlyShipping
{
    public class MonthlyShippingCreateModel
    {
        public MonthlyShippingCreateModel(string description, ICollection<BookItemModel> books, string gift)
        {
            Description = description;
            Books = books;
            Gift = gift;
        }
        public string Description { get; set; }
        public ICollection<BookItemModel> Books { get; set; }
        public string Gift { get; set; }

        public Core.Entities.MonthlyShipping ToEntity()
            => new(Description, null, Gift);
    }
}

