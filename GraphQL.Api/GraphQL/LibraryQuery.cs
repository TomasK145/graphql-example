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
        public LibraryQuery(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => bookRepository.GetAllAsync()
            );

            Field<BookType>(
                "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "bookId"}),
                resolve: context =>
                {
                    var bookId = context.GetArgument<int>("bookId");
                    return bookRepository.GetById(bookId);
                }
            );

            Field<ListGraphType<AuthorType>>(
                "authors",
                resolve: context => authorRepository.GetAllAsync()
            );

            Field<AuthorType>(
                "author",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "authorId"}),
                resolve: context =>
                {
                    var authorId = context.GetArgument<int>("authorId");
                    return authorRepository.GetById(authorId);
                }
            );
        }
    }
}
