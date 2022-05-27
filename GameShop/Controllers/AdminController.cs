using DLL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
