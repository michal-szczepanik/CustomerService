using CustomerService.Api.Abstract;
using CustomerService.Api.Filters;
using CustomerService.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerService.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await customerService.GetCustomersAsync();

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> Add([FromForm]AddCustomerViewModel model)
        {
            var result = await customerService.AddCustomerAsync(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return Ok();
        }

        [HttpPut]
        [ValidateModelFilter]
        public async Task<IActionResult> Edit([FromBody]EditCustomerViewModel model)
        {
            var result = await customerService.EditCustomerAsync(model);

            return Ok(result);
        }

        [HttpDelete]
        //[Route("customer/remove/{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await customerService.RemoveCustomerAsync(id);

            if (!result)
            {
                return BadRequest();
            }

            var model = await customerService.GetCustomersAsync();
            model.IsCustomerRemoved = true;

            return View("_CustomersList", model);
        }
    }
}
