using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class CustomerInputType : InputObjectGraphType
    {
        public CustomerInputType()
        {
            Name = "customerInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("surname");
            Field<NonNullGraphType<AddressInputType>>("address");
        }
    }
}
