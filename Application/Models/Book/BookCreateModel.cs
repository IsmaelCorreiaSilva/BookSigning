
using Core.Entities;

namespace Application.Models.Book
{
    public class BookCreateModel
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Core.Entities.Book ToEntity()
            => new(Title, Summary, PublishingCompany, Author, ReleaseDate);
    }
}
