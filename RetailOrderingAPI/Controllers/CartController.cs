using Microsoft.AspNetCore.Mvc;

namespace RetailOrderingAPI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
