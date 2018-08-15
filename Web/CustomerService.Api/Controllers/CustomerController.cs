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
        public async Task<IActionResult> Edit(string id)
        {
            var model = await customerService.GetCustomerAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateModelFilter]
        public async Task<IActionResult> Edit([FromForm]EditCustomerViewModel model)
        {
            var result = await customerService.EditCustomerAsync(model);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            await customerService.RemoveCustomerAsync(id);

            var model = await customerService.GetCustomersAsync();
            model.IsCustomerRemoved = true;

            return View("_CustomersList", model);
        }
    }
}