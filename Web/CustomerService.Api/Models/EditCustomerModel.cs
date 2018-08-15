using System.ComponentModel.DataAnnotations;

namespace CustomerService.Api.Models
{
    public class EditCustomerModel
    {
        [Required]
        public string Id { get; set; }

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