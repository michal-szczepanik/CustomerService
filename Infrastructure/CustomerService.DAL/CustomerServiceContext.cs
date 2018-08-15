using CustomerService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.DAL
{
    class CustomerServiceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerServiceDatabase;Trusted_Connection=True;");
        }
    }
}