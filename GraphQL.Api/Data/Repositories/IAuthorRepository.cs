using GraphQL.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetById(int authorId);
        Task<List<Author>> GetByBookId(int bookId);
    }
}