using CustomerService.DAL.Repositories.Abstract;
using CustomerService.DAL.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DAL.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using (var ctx = new CustomerServiceContext())
            {
                return await ctx.Customers.ToListAsync();
            }
        }

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

                entity.Name = customer.Name;
                entity.Surname = customer.Surname;
                entity.TelephoneNumber = customer.TelephoneNumber;
                entity.Address = customer.Address;

                await ctx.SaveChangesAsync();

                return customer;
            }
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            using (var ctx = new CustomerServiceContext())
            {
                var entity = ctx.Customers.FirstOrDefault(x => x.Id == id);

                if (entity == null)
                {
                    return false;
                }

                ctx.Customers.Remove(entity);

                await ctx.SaveChangesAsync();

                return true;
            }
        }

        public async Task<Customer> GetCustomerAsync(string id)
        {
            using (var ctx = new CustomerServiceContext())
            {
                return await ctx.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
        }
    }
}