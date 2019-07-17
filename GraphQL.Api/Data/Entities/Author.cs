using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Author //Author a Customer mozu dedit od Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Address Address { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<Book> CreatedBooks { get; set; }
    }
}