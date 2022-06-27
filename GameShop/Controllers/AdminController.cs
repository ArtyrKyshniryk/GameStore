using BLL.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;
        public AdminController(  UserService UserService)
        {
            this._userService = UserService;
        }
        // GET: AdminController
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> ViewAllEmployee()
        {
            return View(await this._userService.GetAllEmployeesAsync());
        }
        public IActionResult AddEmployeerAsync() => View();
        public async Task<IActionResult> AddEmployeerAsync(Employeer employeer)
        {
            await _userService.AddEmployeer(employeer);
            return View("index");
        }
    }
}
