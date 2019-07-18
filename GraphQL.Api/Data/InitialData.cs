using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data
{
    public static class InitialData
    {
        public static void Seed(this LibraryDbContext dbContext)
        {
            if (dbContext.Books.Any())
            {
                return;
            }


        }
    }
}
