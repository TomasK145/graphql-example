using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.GraphQL
{
    public class LibrarySchema : Schema
    {
        public LibrarySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<LibraryQuery>();
        }
    }
}
