using GraphQL.Api.Data.Entities;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class ContactType : ObjectGraphType<Contact>
    {
        public ContactType()
        {
            Field(t => t.Value);
            Field(t => t.Description);
            Field<ContactTypeType>(Name = "ContactType", Description = "The type of contact");
        }
    }
}
