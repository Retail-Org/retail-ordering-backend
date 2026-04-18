using Microsoft.AspNetCore.Mvc;

namespace RetailOrderingAPI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
