using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType(IBookRepository bookRepository)
        {
            Field(t => t.AuthorId);
            Field(t => t.Name);
            Field(t => t.Surname);
            Field<AddressType>("Address");
            Field<ListGraphType<ContactType>>("Contact");
            Field<ListGraphType<BookType>>(
                "books",
                resolve: context => bookRepository.GetByAuthorId(context.Source.AuthorId)
            );
        }
    }
}
