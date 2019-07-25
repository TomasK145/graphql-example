using GraphQL.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphQL.Api.Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllAsync();
        Task<Customer> GetById(int customerId);
    }
}