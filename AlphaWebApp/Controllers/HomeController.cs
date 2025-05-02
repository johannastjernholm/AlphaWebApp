using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Login", "Auth");
        }
    }
}
