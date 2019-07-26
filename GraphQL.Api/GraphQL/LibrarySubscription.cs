using GraphQL.Api.GraphQL.Messaging;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL
{
    public class LibrarySubscription : ObjectGraphType
    {
        public LibrarySubscription(CustomerMessageService customerMessageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "customerAdded",
                Type = typeof(CustomerAddedMessageType),
                Resolver = new FuncFieldResolver<CustomerAddedMessage>(c => c.Source as CustomerAddedMessage),
                Subscriber = new EventStreamResolver<CustomerAddedMessage>(c => customerMessageService.GetMessages())
            });
        }
    }
}
