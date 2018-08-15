using CustomerService.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Api.Abstract
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerModel>> GetCustomersAsync();

        Task<CustomerModel> AddCustomerAsync(AddCustomerModel model);

        Task<CustomerModel> EditCustomerAsync(EditCustomerModel model);

        Task<bool> RemoveCustomerAsync(string id);
    }
}