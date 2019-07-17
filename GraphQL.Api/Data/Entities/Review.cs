namespace GraphQL.Api.Data.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReviewAuthorId { get; set; }
        public Customer ReviewAuthor { get; set; }
        public int Rating { get; set; }
        public string ReviewMessage { get; set; }
    }
}