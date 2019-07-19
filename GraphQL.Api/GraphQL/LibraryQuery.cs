using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL
{
    public class LibraryQuery : ObjectGraphType
    {
        public LibraryQuery(IBookRepository bookRepository)
        {
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => bookRepository.GetAllAsync()
            );
        }
    }
}
