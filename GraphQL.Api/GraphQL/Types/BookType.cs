﻿using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(IAuthorRepository authorRepository, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.BookId);
            Field(t => t.Title);
            Field<GenreType>("Genre", "The genre of book");
            Field(t => t.PageCount);
            Field<ListGraphType<AuthorType>>(
                "authors",
                //resolve: context => authorRepository.GetByBookId(context.Source.BookId) //klasicke resolvovanie graphql typu
                resolve: context => { //resolvovanie pouzitim Data Loaderu
                    var loader = dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, Author>("GetAuthorById", authorRepository.GetByBookIdList);
                    return loader.LoadAsync(context.Source.BookId);
                }
            );
            Field<BookStatusType>("BookStatus", "Availability of book");
            Field<ListGraphType<ReviewType>>("Reviews");
        }
    }
}
