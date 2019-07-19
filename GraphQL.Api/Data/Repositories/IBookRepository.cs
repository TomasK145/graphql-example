using GraphQL.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
    }
}
