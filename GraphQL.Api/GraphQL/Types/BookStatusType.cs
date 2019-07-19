using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class BookStatusType : EnumerationGraphType<BookStatus>
    {
        public BookStatusType()
        {
            Name = "BookStatus";
            Description = "The availability of book";
        }
    }
}
