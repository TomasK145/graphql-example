using GraphQL.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Book>> GetAllAsync()
        {
            return _dbContext.Books
                                .Include(b => b.Reviews)
                                .ToListAsync();
        }

        public Task<Book> GetById(int bookId)
        {
            return _dbContext.Books
                                .Include(b => b.Reviews)
                                .FirstAsync(b => b.BookId.Equals(bookId));
        }

        public Task<List<Book>> GetByAuthorId(int authorId)
        {
            return _dbContext.Books
                                .Include(b => b.Reviews)
                                .Where(b => b.Authors.Any(p => p.AuthorId.Equals(authorId)))
                                .ToListAsync();
        }
    }
}
