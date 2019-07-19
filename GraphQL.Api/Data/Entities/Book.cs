using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorBook> Authors { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public BookStatus BookStatus { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
