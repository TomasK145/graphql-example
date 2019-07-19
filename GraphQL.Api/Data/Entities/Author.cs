using System.Collections.Generic;

namespace GraphQL.Api.Data.Entities
{
    public class Author //Author a Customer mozu dedit od Person
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //[ComplexType] --> not implemented in EF Core yet
        public Address Address { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<AuthorBook> CreatedBooks { get; set; }
    }
}