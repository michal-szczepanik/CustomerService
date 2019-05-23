using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
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