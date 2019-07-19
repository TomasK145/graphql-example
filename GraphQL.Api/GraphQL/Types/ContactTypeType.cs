using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class ContactTypeType : EnumerationGraphType<ContactType>
    {
        public ContactTypeType()
        {
            Name = "ContactType";
            Description = "The type of contact";
        }
    }
}
