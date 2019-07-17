using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
