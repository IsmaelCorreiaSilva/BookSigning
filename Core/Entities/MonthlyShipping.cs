
namespace Core.Entities
{
    public class MonthlyShipping
    {
        public MonthlyShipping(int id, string description,ICollection<Book> books, string gift)
        {
            Id = id;
            Description = description;
            Books = books;
            Gift = gift;
        }
        public MonthlyShipping(string description,ICollection<Book> books, string gift)
        {
            Description = description;
            Books = books;
            Gift = gift;
        }
        public int Id { get; private set; }
        public string Description { get; private set; }
        public ICollection<Book> Books { get; private set; }
        public string Gift { get; private set; }

        public bool OwnsOneOrMoreBook()
        {
            return true;
        }
    }
}
