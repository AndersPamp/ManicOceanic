using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManicOceanic.DATA.Data;
using ManicOceanic.DOMAIN.Entities;
using ManicOceanic.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManicOceanic.WEB.Controllers
{
  public class AccountsController : Controller
  {
    private readonly MOContext _context;
    private readonly UserManager<Customer> _userManager;

    public AccountsController(
        MOContext context,
        UserManager<Customer> userManager)
    {
      _context = context;
      _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AssignRoles(List<RoleCheckBoxViewModel> roleCheckBoxViewModel)
    {
      System.Diagnostics.Debug.WriteLine("AssignRoles is calledddddddd" + roleCheckBoxViewModel[0].customer.SecurityStamp);
      System.Diagnostics.Debug.WriteLine("AssignRoles is calledddddddd" + roleCheckBoxViewModel[0].customer.SecurityStamp);
      System.Diagnostics.Debug.WriteLine("AssignRoles is calledddddddd" + roleCheckBoxViewModel[0].customer.SecurityStamp);
      var currentUser = await _userManager.FindByEmailAsync(roleCheckBoxViewModel[0].customer.Email);
      var iListUsersRoles = _userManager.GetRolesAsync(currentUser);
      var theList = iListUsersRoles.Result;
      var usersRoles = new List<string>(theList);

      await _userManager.RemoveFromRolesAsync(currentUser, usersRoles);
      foreach (var item in roleCheckBoxViewModel)
      {
        System.Diagnostics.Debug.WriteLine("Item selected status: " + item.Selected + "ööööööööööö");
        System.Diagnostics.Debug.WriteLine("Item selected status: " + item.Selected + "ööööööööööö");
        if (item.Selected)
        {
          System.Diagnostics.Debug.WriteLine("Inside IF: ööööööööööö");
          await _userManager.AddToRoleAsync(currentUser, item.RoleName);
        }
        System.Diagnostics.Debug.WriteLine("Email: " + item.customer.Email);
        System.Diagnostics.Debug.WriteLine("RoleName: " + item.RoleName);
        System.Diagnostics.Debug.WriteLine("Selected: " + item.Selected);
        System.Diagnostics.Debug.WriteLine("***************************");
      }
      // Ta bort allt från ApsUserRoles med den här användaren.
      // Lägg till användaren med de roller som är inklickade.
      return RedirectToAction("Details", "Accounts", new { id = roleCheckBoxViewModel[0].customer.Email });
    }

    public async Task<IActionResult> Details(string id)
    {
      if (id == null)
      {
        return NotFound();
      }
      AssignRolesViewModel assignRolesViewModel = new AssignRolesViewModel();

      var identityUser = await _userManager.FindByEmailAsync(id);

      assignRolesViewModel.customer = identityUser;
      var iListUsersRoles = _userManager.GetRolesAsync(identityUser);
      var theList = iListUsersRoles.Result;
      var usersRoles = new List<string>(theList);

      var allRoles = _context.Roles.ToList();

      List<RoleCheckBoxViewModel> checkBoxes = new List<RoleCheckBoxViewModel>();

      foreach (var item in allRoles)
      {
        RoleCheckBoxViewModel cBox = new RoleCheckBoxViewModel();
        cBox.RoleId = item.Id;
        cBox.RoleName = item.Name;
        cBox.customer = identityUser;
        if (usersRoles.Contains(item.Name))
        {
          cBox.Selected = true;
        }
        else
        {
          cBox.Selected = false;
        }
        checkBoxes.Add(cBox);
      }

      assignRolesViewModel.IdentityRoles = checkBoxes;

      ViewData["UserName"] = "Hello World!";

      return View(checkBoxes);
    }

    public IActionResult Index()
    {
      List<Customer> allUsers = _userManager.Users.ToList();
      List<UserAndRolesViewModel> list = new List<UserAndRolesViewModel>();
      foreach (var item in allUsers)
      {
        UserAndRolesViewModel userAndRoles = new UserAndRolesViewModel();
        var iListUsersRoles = _userManager.GetRolesAsync(item);
        var theList = iListUsersRoles.Result;
        var usersRoles = new List<string>(theList);
        foreach (var role in usersRoles)
        {
          System.Diagnostics.Debug.WriteLine("**********************************************");
          System.Diagnostics.Debug.WriteLine("Fetched role: " + role);
        }
        System.Diagnostics.Debug.WriteLine("**********************************************");
        System.Diagnostics.Debug.WriteLine("Users email: " + item.Email);
        userAndRoles.customer = item;
        userAndRoles.roles = usersRoles;
        list.Add(userAndRoles);
        theList = null;
      }
      return View(list);
    }
  }
}