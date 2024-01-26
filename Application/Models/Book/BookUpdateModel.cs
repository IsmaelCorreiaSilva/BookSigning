
namespace Application.Models.Book
{
    public class BookUpdateModel
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Core.Entities.Book ToEntity()
            => new(Id, Title, Summary, PublishingCompany, Author, ReleaseDate);
    }
}
