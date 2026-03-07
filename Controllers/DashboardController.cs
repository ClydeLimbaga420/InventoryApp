using InventoryApp.Data;
using InventoryApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var totalProducts = await _context.Products.CountAsync();
            var totalUsers = _userManager.Users.Count();
            var totalCategories = await _context.Products
                .Select(p => p.Category)
                .Distinct()
                .CountAsync();

            var latestProducts = await _context.Products
                .OrderByDescending(p => p.DateAdded)
                .Take(5)
                .ToListAsync();

            var vm = new DashboardViewModel
            {
                TotalProducts = totalProducts,
                TotalUsers = totalUsers,
                TotalCategories = totalCategories,
                LatestProducts = latestProducts
            };

            return View(vm);
        }
    }
}
