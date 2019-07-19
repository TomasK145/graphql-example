using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IAuthorRepository authorRepository)
        {
            Field(t => t.BookId);
            Field(t => t.Title);
            Field<GenreType>("Genre", "The genre of book");
            Field(t => t.PageCount);
            Field<ListGraphType<AuthorType>>(
                "authors",
                resolve: context => authorRepository.GetByBookId(context.Source.BookId)
            );
            Field<BookStatusType>("BookStatus", "Availability of book");
        }
    }
}
