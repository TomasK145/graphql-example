using GraphQL.Api.Data.Entities;
using GraphQL.Api.Data.Repositories;
using GraphQL.Api.GraphQL.Messaging;
using GraphQL.Api.GraphQL.Types;
using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    public class LibraryMutation : ObjectGraphType
    {
        public LibraryMutation(ICustomerRepository customerRepository, CustomerMessageService customerMessageService)
        {
            FieldAsync<CustomerType>(
                "createCustomer",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CustomerInputType>> { Name = "customer" }), //Mutation musi mat ako parameter Input graph type
                resolve: async context =>
                {
                    var customer = context.GetArgument<Customer>("customer");
                    //return await context.TryAsyncResolve(async c => await customerRepository.AddCustomer(customer));

                    await customerRepository.AddCustomer(customer);
                    customerMessageService.AddCustomerAddedMessage(customer);
                    return customer;
                }
            );
        }
    }
}