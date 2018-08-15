using CustomerService.Api.Models;
using CustomerService.DAL.Entities;

namespace CustomerService.Api.Mappers
{
    public static class CustomerMapper
    {
        public static Customer Map(AddCustomerModel customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,
                TelephoneNumber = customer.TelephoneNumber
            };
        }

        public static CustomerModel Map(Customer customer)
        {
            return new CustomerModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                TelephoneNumber = customer.TelephoneNumber,
                Address = customer.Address
            };
        }

        public static Customer Map(EditCustomerModel customer)
        {
            return new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,
                TelephoneNumber = customer.TelephoneNumber
            };
        }
    }
}