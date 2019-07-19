using GraphQL.Api.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Field(t => t.AuthorId);
            Field(t => t.Name);
            Field(t => t.Surname);
            Field<AddressType>("Address");
            Field<ListGraphType<ContactType>>("Contact");
        }
    }
}
