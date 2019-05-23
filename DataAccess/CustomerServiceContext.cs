using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerServiceContext : DbContext
    {
        public CustomerServiceContext(DbContextOptions<CustomerServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}