using CustomerService.Api.Models;
using System.Threading.Tasks;

namespace CustomerService.Api.Abstract
{
    public interface ICustomerService
    {
        Task<CustomerModel> AddCustomerAsync(AddCustomerModel model);

        Task<CustomerModel> EditCustomerAsync(EditCustomerModel model);
    }
}