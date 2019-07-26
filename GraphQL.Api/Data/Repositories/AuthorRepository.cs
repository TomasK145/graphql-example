using GraphQL.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDbContext _dbContext;
        public AuthorRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Author>> GetAllAsync()
        {
            return _dbContext.Authors
                                .Include(a => a.Address)
                                .ToListAsync();
        }

        public Task<Author> GetById(int authorId)
        {
            return _dbContext.Authors
                                .Include(a => a.Address)
                                .FirstOrDefaultAsync(a => a.AuthorId.Equals(authorId));
        }

        public Task<List<Author>> GetByBookId(int bookId)
        {
            return _dbContext.Authors
                                .Include(a => a.Address)
                                .Where(a => a.CreatedBooks.Any(b => b.BookId.Equals(bookId)))
                                .ToListAsync();
        }

        public async Task<ILookup<int, Author>> GetByBookIdList(IEnumerable<int> bookIdList)
        {
            var authors = await _dbContext.Authors.Where(a => a.CreatedBooks.Any(b => bookIdList.Contains(b.AuthorId))).ToListAsync();
            return authors.ToLookup(a => a.AuthorId);
        }
    }
}
