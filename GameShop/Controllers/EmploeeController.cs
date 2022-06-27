using BLL.Services;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class EmploeeController : Controller
    {
        private readonly UserService _userService;
        public EmploeeController( UserService userService)
        {
            this._userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EmployeeList(string Category)
        {
            EmployeeListModel model = new EmployeeListModel();

            if (Category == null)
                model.Employees = (await _userService.GetAllEmployeesAsync()).ToList();

            
            return View(model);
        }
        public async Task<IActionResult> EmployeeInfPage(int Id)
        {
            return View(await this._userService.GetEmployeeByIdAsync(Id));
        }
    }
}
