using System.Threading.Tasks;
using DataAccess.Repositories.Abstract;
using WebApp.Abstract;
using WebApp.Mappers;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<CustomersViewModel> GetCustomersAsync()
        {
            var customers = await customerRepository.GetCustomersAsync();

            var result = CustomerMapper.Map(customers);

            return result;
        }

        public async Task<CustomerViewModel> AddCustomerAsync(AddCustomerViewModel model)
        {
            var customerEntity = CustomerMapper.Map(model);

            var customer = await customerRepository.AddCustomerAsync(customerEntity);

            var result = CustomerMapper.Map(customer);

            return result;
        }

        public async Task<CustomerViewModel> EditCustomerAsync(EditCustomerViewModel model)
        {
            var customerEntity = CustomerMapper.Map(model);

            var customer = await customerRepository.EditCustomerAsync(customerEntity);

            var result = CustomerMapper.Map(customer);

            return result;
        }

        public Task<bool> RemoveCustomerAsync(string id)
        {
            return customerRepository.DeleteCustomerAsync(id);
        }

        public async Task<EditCustomerViewModel> GetCustomerAsync(string id)
        {
            var customer = await customerRepository.GetCustomerAsync(id);

            var model = CustomerMapper.MapToEditCustomerViewModel(customer);

            return model;
        }
    }
}