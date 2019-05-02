using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}