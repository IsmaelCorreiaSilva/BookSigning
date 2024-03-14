
using Application.Models.Book;

namespace Application.Models.MonthlyShipping
{
    public class MonthlyShippingUpdateModel
    {
        public MonthlyShippingUpdateModel(int id, string description, ICollection<BookItemModel> books, string gift)
        {
            Id = id;
            Description = description;
            Books = books;
            Gift = gift;
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<BookItemModel> Books { get; set; }
        public string Gift { get; set; }

        public Core.Entities.MonthlyShipping ToEntity()
            => new(Id, Description, null, Gift);
    }
}
