using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
