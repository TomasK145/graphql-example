using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Book> BorrowedBooks { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
