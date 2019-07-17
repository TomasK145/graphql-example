using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public BookStatus BookStatus { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
