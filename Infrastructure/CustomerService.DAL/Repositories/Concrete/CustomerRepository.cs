using CustomerService.DAL.Repositories.Abstract;
using System;
using CustomerService.DAL.Entities;
using System.Threading.Tasks;

namespace CustomerService.DAL.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            using (var ctx = new CustomerServiceContext())
            {
                var result = ctx.Customers.Add(customer);

                await ctx.SaveChangesAsync();

                return result.Entity;
            }
        }

        public Customer EditCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}