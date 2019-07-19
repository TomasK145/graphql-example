using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class AddressType : ObjectGraphType<Address>
    {
        public AddressType()
        {
            Field(t => t.Country);
            Field(t => t.City);
            Field(t => t.Street);
            Field(t => t.StreetNumber);
            Field(t => t.PostCode);
        }
    }
}
