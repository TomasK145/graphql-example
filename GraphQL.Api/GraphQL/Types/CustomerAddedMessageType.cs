using GraphQL.Api.GraphQL.Messaging;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL.Types
{
    public class CustomerAddedMessageType : ObjectGraphType<CustomerAddedMessage>
    {
        public CustomerAddedMessageType()
        {
            Field(t => t.CustomerId);
            Field(t => t.Name);
            Field(t => t.Surname);
        }
    }
}
