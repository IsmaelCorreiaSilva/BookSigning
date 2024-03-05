
namespace Application.Models.MonthlyShipping
{
    public class MonthlyShippingCreateModel
    {
        public MonthlyShippingCreateModel(string description, int bookId, string gift)
        {
            Description = description;
            BookId = bookId;
            Gift = gift;
        }
        public string Description { get; set; }
        public int BookId { get; set; }
        public string Gift { get; set; }

        public Core.Entities.MonthlyShipping ToEntity()
            => new(Description, null, Gift);
    }
}

