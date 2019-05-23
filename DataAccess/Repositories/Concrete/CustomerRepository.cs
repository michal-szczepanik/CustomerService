using DataAccess.Repositories.Abstract;
using DataAccess.Entities;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerServiceContext context;

        public CustomerRepository(CustomerServiceContext context)
        {
            this.context = context;
        }

        public Task<List<Customer>> GetCustomersAsync() =>
            context.Customers.ToListAsync();

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            var result = context.Customers.Add(customer);
            await context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Customer> EditCustomerAsync(Customer customer)
        {
            var entity = context.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (entity == null)
                return null;

            entity.Name = customer.Name;
            entity.Surname = customer.Surname;
            entity.TelephoneNumber = customer.TelephoneNumber;
            entity.Address = customer.Address;
            await context.SaveChangesAsync();

            return customer;
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var entity = context.Customers.FirstOrDefault(x => x.Id == id);
            if (entity == null)
                return false;

            context.Customers.Remove(entity);
            await context.SaveChangesAsync();

            return true;
        }

        public Task<Customer> GetCustomerAsync(string id) =>
            context.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }
}