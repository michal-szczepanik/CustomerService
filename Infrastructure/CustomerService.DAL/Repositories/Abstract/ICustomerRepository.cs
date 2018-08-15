using CustomerService.DAL.Entities;
using System.Threading.Tasks;

namespace CustomerService.DAL.Repositories.Abstract
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);

        Task<Customer> EditCustomerAsync(Customer customer);

        Task<bool> DeleteCustomerAsync(string id);
    }
}