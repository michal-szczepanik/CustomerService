using CustomerService.DAL.Repositories.Abstract;
using System;
using CustomerService.DAL.Entities;
using System.Threading.Tasks;
using System.Linq;

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

        public async Task<Customer> EditCustomerAsync(Customer customer)
        {
            using (var ctx = new CustomerServiceContext())
            {
                var entity = ctx.Customers.FirstOrDefault(x => x.Id == customer.Id);

                if(entity == null)
                {
                    return null;
                }

                entity = customer;

                await ctx.SaveChangesAsync();

                return customer;
            }
        }
    }
}