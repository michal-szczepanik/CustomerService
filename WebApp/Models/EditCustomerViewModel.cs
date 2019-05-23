using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class EditCustomerViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Display(Name = "Telephone number")]
        [Range(100000000, 999999999, ErrorMessage = "The thelephone number can only contain numbers and has to be 9 numbers long")]
        public int TelephoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}