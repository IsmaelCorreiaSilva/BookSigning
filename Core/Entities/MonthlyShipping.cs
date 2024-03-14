
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

        public void AddBook(ICollection<Book> books)
        {
            if(books != null) 
                Books = books;
        }
        public bool OwnsOneOrMoreBook()
        {
            return Books.Count > 0;
        }
    }
}
