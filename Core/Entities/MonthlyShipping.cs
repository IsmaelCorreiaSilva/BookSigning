
namespace Core.Entities
{
    public class MonthlyShipping
    {
        public MonthlyShipping(int id, string description, Book book, string gift)
        {
            Id = id;
            Description = description;
            Book = book;
            Gift = gift;
        }
        public MonthlyShipping(string description, Book book, string gift)
        {
            Description = description;
            Book = book;
            Gift = gift;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public Book Book { get; private set; }
        public string Gift { get; private set; }
    }
}
