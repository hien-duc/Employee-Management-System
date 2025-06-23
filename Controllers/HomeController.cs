using Microsoft.AspNetCore.Mvc;
using Employee_Management_System.Models;
using System.Diagnostics;
using Employee_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dashboardViewModel = new Models.ViewModels.DashboardViewModel
            {
                TotalEmployees = await _context.Employees.CountAsync(),
                TotalDepartments = await _context.Departments.CountAsync(),
                RecentlyHiredEmployees = await _context.Employees
                    .Include(e => e.Department)
                    .OrderByDescending(e => e.HireDate)
                    .Take(5)
                    .ToListAsync(),
                Carousels = await _context.Carousels.Where(c => c.IsActive).ToListAsync()
            };

            return View(dashboardViewModel);
        }

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
