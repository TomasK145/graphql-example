using GraphQL.Types;
using data = GraphQL.Api.Data;

namespace GraphQL.Api.GraphQL.Types
{
    public class ContactTypeType : EnumerationGraphType<data.ContactType>
    {
        public ContactTypeType()
        {
            Name = "ContactType";
            Description = "The type of contact";
        }
    }
}
