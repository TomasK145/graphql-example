using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType(IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            Field(t => t.Id);
            Field(t => t.Rating);
            Field(t => t.ReviewMessage);
            Field<BookType>(
                "book",
                resolve: context => bookRepository.GetById(context.Source.BookId)
            );
            Field<CustomerType>(
                "customer",
                resolve: context => customerRepository.GetById(context.Source.ReviewAuthorId)
            );
        }
    }
}
