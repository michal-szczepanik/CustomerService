using System.Web.Http;

namespace CustomerService.Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddCustomer()
        {
            return Ok();
        }
    }
}
