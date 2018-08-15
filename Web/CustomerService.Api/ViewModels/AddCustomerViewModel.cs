using System.ComponentModel.DataAnnotations;

namespace CustomerService.Api.ViewModels
{
    public class AddCustomerViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int TelephoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}