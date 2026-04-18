using Microsoft.AspNetCore.Mvc;

namespace RetailOrderingAPI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
