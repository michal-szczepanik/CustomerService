using System.Threading.Tasks;
using CustomerService.Api.Abstract;
using CustomerService.Api.Models;
using CustomerService.DAL.Repositories.Abstract;
using CustomerService.Api.Mappers;

namespace CustomerService.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomerModel> AddCustomerAsync(AddCustomerModel model)
        {
            var customerEntity = CustomerMapper.Map(model);

            var customer = await customerRepository.AddCustomerAsync(customerEntity);

            var result = CustomerMapper.Map(customer);

            return result;
        }
    }
}