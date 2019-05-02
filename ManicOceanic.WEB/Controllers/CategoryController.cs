using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManicOceanic.WEB.Models;

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