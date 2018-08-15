using System.Collections.Generic;

namespace CustomerService.Api.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public bool IsCustomerRemoved { get; set; }
    }
}
