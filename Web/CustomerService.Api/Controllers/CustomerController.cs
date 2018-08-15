using CustomerService.Api.Models;
using CustomerService.Api.Filters;
using System.Web.Http;
using CustomerService.Api.Abstract;
using System.Threading.Tasks;

namespace CustomerService.Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("add")]
        [ValidateModelFilter]
        public async Task<IHttpActionResult> AddCustomer([FromBody]AddCustomerModel model)
        {
            var result = await customerService.AddCustomerAsync(model);

            return Ok(result);
        }
    }
}
