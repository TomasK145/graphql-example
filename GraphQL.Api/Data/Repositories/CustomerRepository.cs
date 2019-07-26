using GraphQL.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LibraryDbContext _dbContext;

        public CustomerRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _dbContext.Customers
                                .Include(c => c.Reviews)
                                .Include(c => c.Address)
                                .Include(c => c.Contacts)
                                .Include(c => c.BorrowedBooks)
                                .ToListAsync();
        }

        public Task<Customer> GetById(int customerId)
        {
            return _dbContext.Customers
                                .Include(c => c.Reviews)
                                .Include(c => c.Address)
                                .Include(c => c.Contacts)
                                .Include(c => c.BorrowedBooks)
                                .FirstAsync(c => c.Id.Equals(customerId));
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
