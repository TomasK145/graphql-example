﻿namespace GraphQL.Api.Data.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType ContactType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}