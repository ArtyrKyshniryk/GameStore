using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserService userService;
        public ProductController(UserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult AddProduct() => View();
        public async Task<IActionResult>AddProductAsync(Product product,int employeeId)
        {
            if(employeeId !=null)
            {
                await userService.AddProductAsync(product, employeeId);
                return View("Index");
            }
            return RedirectToRoute(new {Controller = "Home", Action = "Index"});
        }



        public IActionResult AddToOrder() => View();
        public async Task<IActionResult>AddToOrderAsync(Product product, int orderId)
        {
            if (orderId != null)
            {
                await userService.AddToOrderAsync(product, orderId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }



        public IActionResult ChangeProduct() => View();
        public async Task<IActionResult>ChangeProductAsync(Product newProduct, int olDProductId)
        {
            if (olDProductId != null)
            {
                await userService.ChangeProductAsync(newProduct, olDProductId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }



        public IActionResult RemoveProductFromOrder() => View();
        public async Task<IActionResult>RemoveProductFromOrderAsync(int orderId, int remProductId)
        {
            if (orderId != null && remProductId != null)
            {
                await userService.RemoveProductFromOrderAsync(orderId, remProductId);
                return View("Index");
            }
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }
    }
}
