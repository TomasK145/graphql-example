using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    internal class AddressInputType : InputObjectGraphType
    {
        public AddressInputType()
        {
            Name = "addressInput";
            Field<NonNullGraphType<StringGraphType>>("country");
            Field<NonNullGraphType<StringGraphType>>("city");
            Field<NonNullGraphType<StringGraphType>>("street");
            Field<NonNullGraphType<StringGraphType>>("streetNumber");
            Field<NonNullGraphType<StringGraphType>>("postCode");
        }
    }
}