using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class CustomerServiceContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CustomerServiceDatabase;Trusted_Connection=True;");
        }
    }
}