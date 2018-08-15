using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Api.Controllers
{
    public class InfoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}