using CustomerService.DAL.Entities;
using System.Threading.Tasks;

namespace CustomerService.DAL.Repositories.Abstract
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomerAsync(Customer customer);

        Customer EditCustomer(Customer customer);
    }
}