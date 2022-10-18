using EmployeeManagmentWeb.Models;
using EmployeeManagmentWeb.Repositry.IRepositry;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeManagmentWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private IEmployeeRepositry _employeeRepositry;

        public HomeController(ILogger<HomeController> logger/*, IEmployeeRepositry employee*/)
        {
            //_employeeRepositry = employee;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return _employeeRepositry.GetEmployee(1).ToString();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}