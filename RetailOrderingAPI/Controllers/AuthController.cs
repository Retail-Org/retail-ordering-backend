using Microsoft.AspNetCore.Mvc;

namespace RetailOrderingAPI.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
