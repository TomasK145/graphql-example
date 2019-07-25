using GraphQL.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetById(int bookId);
        Task<List<Book>> GetByListId(List<int> bookIdList);
        Task<List<Book>> GetByAuthorId(int authorId);
    }
}
