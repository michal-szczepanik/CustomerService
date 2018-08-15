using CustomerService.Api.Abstract;
using CustomerService.Api.Filters;
using CustomerService.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.Api.Controllers
{
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("add")]
        [ValidateModelFilter]
        public async Task<IActionResult> AddCustomer([FromBody]AddCustomerModel model)
        {
            var result = await customerService.AddCustomerAsync(model);

            return Ok(result);
        }

        [HttpPut]
        [Route("edit")]
        [ValidateModelFilter]
        public async Task<IActionResult> EditCustomer([FromBody]EditCustomerModel model)
        {
            var result = await customerService.EditCustomerAsync(model);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
