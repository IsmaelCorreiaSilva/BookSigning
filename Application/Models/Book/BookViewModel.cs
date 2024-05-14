
namespace Application.Models.Book
{
    public class BookViewModel
    {
        public BookViewModel(int id,string title, string summary, string publishingCompany, string author, DateTime releaseDate)
        {
            this.Id = id;
            this.Title = title;
            this.Summary = summary;
            this.PublishingCompany = publishingCompany;
            this.Author = author;
            this.ReleaseDate = releaseDate;
        }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }

        public static BookViewModel FromEntity(Core.Entities.Book book)
            => new(book.Id, book.Title, book.Summary, book.PublishingCompany, book.Author, book.ReleaseDate);

        public static IEnumerable<BookViewModel> EntityListForViewModelList(IEnumerable<Core.Entities.Book> books)
        {
            var listBooks = new List<BookViewModel>();
            foreach (var item in books)
            {
                listBooks.Add(FromEntity(item));
            }
            return listBooks;
        }
    }
}
