using CustomerService.Api.Abstract;
using CustomerService.Api.Filters;
using CustomerService.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.Api.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var result = await customerService.GetCustomersAsync();

            return View(result);
        }

        [HttpGet]
        [Route("add")]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        [ValidateModelFilter]
        public async Task<IActionResult> AddCustomer([FromBody]AddCustomerViewModel model)
        {
            var result = await customerService.AddCustomerAsync(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("edit")]
        public IActionResult EditCustomer()
        {
            return Ok();
        }

        [HttpPut]
        [Route("edit")]
        [ValidateModelFilter]
        public async Task<IActionResult> EditCustomer([FromBody]EditCustomerViewModel model)
        {
            var result = await customerService.EditCustomerAsync(model);

            return Ok(result);
        }

        [HttpDelete]
        [Route("remove/{id}")]
        public async Task<IActionResult> RemoveCustomer(string id)
        {
            var result = await customerService.RemoveCustomerAsync(id);

            if(!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
