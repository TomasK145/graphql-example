using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Api.GraphQL.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IBookRepository bookRepository)
        {
            Field(t => t.Id);
            Field(t => t.Name);
            Field(t => t.Surname);
            Field<AddressType>("Address");
            Field<ListGraphType<ContactType>>("Contacts");
            Field<ListGraphType<BookType>>(
               "borrowedBooks",
               resolve: context =>
               {                   
                   List<int> borrowedBookIdList = context.Source.BorrowedBooks?.Select(b => b.BookId).ToList() ?? new List<int>();
                   return bookRepository.GetByListId(borrowedBookIdList);
               }
            );
            Field<ListGraphType<ReviewType>>("Reviews");
        }
    }
}
