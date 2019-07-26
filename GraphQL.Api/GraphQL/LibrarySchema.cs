using GraphQL.Types;

namespace GraphQL.Api.GraphQL
{
    public class LibrarySchema : Schema
    {
        public LibrarySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<LibraryQuery>();
            Mutation = resolver.Resolve<LibraryMutation>();
        }
    }
}
