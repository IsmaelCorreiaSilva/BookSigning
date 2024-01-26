
namespace Core.Entities
{
    public class Book
    {
        public Book() { }
        public Book(int id, string title, string summary, string publishingCompany, string author, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            Summary = summary;
            PublishingCompany = publishingCompany;
            Author = author;
            ReleaseDate = releaseDate;
        }
        public Book(string title, string summary, string publishingCompany, string author, DateTime releaseDate)
        {
            Title = title;
            Summary = summary; 
            PublishingCompany = publishingCompany;
            Author = author;
            ReleaseDate = releaseDate;
        }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
