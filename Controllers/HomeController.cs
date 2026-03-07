using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
{
    if (User.Identity?.IsAuthenticated == true)
        return RedirectToAction("Index", "Dashboard");

    return Redirect("/Identity/Account/Login");
}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
