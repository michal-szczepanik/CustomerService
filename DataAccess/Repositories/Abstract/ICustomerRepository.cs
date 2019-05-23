using DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Abstract
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAsync(string id);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> AddCustomerAsync(Customer customer);

        Task<Customer> EditCustomerAsync(Customer customer);

        Task<bool> DeleteCustomerAsync(string id);
    }
}