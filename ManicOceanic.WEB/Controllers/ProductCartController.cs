using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class ProductCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}