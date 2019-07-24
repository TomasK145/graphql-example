using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Rating);
            Field(t => t.ReviewMessage);
        }
    }
}
