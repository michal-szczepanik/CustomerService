using System.Collections.Generic;

namespace WebApp.ViewModels
{
    public class CustomersViewModel
    {
        public IEnumerable<CustomerViewModel> Customers { get; set; }

        public bool IsCustomerRemoved { get; set; }
    }
}
