using CustomerService.Api.ViewModels;
using CustomerService.DAL.Entities;
using System.Collections.Generic;

namespace CustomerService.Api.Mappers
{
    public static class CustomerMapper
    {
        public static Customer Map(AddCustomerViewModel customer)
        {
            return new Customer
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Address = customer.Address,
                TelephoneNumber = customer.TelephoneNumber
            };
        }

        public static CustomerViewModel Map(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                TelephoneNumber = customer.TelephoneNumber,
                Address = customer.Address
            };
        }

        public static EditCustomerViewModel MapToEditCustomerViewModel(Customer customer)
        {
            return new EditCustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                TelephoneNumber = customer.TelephoneNumber,
                Address = customer.Address
            };
        }

        public static Customer Map(EditCustomerViewModel customer)
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

        public static CustomersViewModel Map(IEnumerable<Customer> customers)
        {
            var model = new List<CustomerViewModel>();

            foreach (var customer in customers)
            {
                var mappedCustomer = Map(customer);
                model.Add(mappedCustomer);
            }

            return new CustomersViewModel
            {
                Customers = model
            };
        }
    }
}