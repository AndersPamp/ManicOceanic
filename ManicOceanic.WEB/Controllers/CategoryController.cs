using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
    public class CategoryController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}