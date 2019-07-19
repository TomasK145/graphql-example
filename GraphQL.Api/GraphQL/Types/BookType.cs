using GraphQL.Api.Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Field(t => t.BookId);
            Field(t => t.Title);
            Field<GenreType>("Genre", "The genre of book");
            Field(t => t.PageCount);
        }
    }
}
