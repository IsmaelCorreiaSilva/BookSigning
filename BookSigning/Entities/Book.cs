﻿namespace BookSigning.Entities
{
    public class Book
    {
        public Book() { }
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set;}
        public DateTime ReleaseDate { get; set; }
    }
}
