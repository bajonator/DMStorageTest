using Microsoft.AspNetCore.Mvc;
using DMStorage.Core.Models.Domains;
using DMStorage.Helpers;
using DMStorage.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DMStorage.Persistence.Repositories;
using DMStorage.Persistence;
using DMStorage.Persistence.Services;
using DMStorage.Core.Service;

public class AccountController : Controller
{
    private IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User model)
    {
        var defaultRole = new Role();

        if (_accountService.UserNameExists(model.Username))
        {
            ModelState.AddModelError("Username", "Tento nazev uzivatela uz je pouzivan.");
        }

        if (_accountService.UserEmailExists(model.Email))
        {
            ModelState.AddModelError("Email", "Tento email uz je zaregistrovan v databazi.");
        }

        if (ModelState.IsValid)
        {
            var users = _accountService.GetUsers();

            if (users.Count == 0)
                defaultRole = _accountService.GetUserForFirstRegister();
            else
                defaultRole = _accountService.GetUserForRegister();

            model.RoleId = defaultRole.Id;
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            _accountService.AddUser(model);

            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User model)
    {
        ModelState.Remove("Email");
        if (ModelState.IsValid)
        {
            var user = _accountService.GetUserByUserName(model.Username);
            if (user != null && BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                SetSession.Session(HttpContext, user);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Password", "Zkontroluj jestli login a heso jsou spravne.");
        }
        return View("Login", model);
    }

    [HttpPost]
    public IActionResult Logout()
    {
        foreach (var item in HttpContext.Session.Keys)
        {
            HttpContext.Session.Remove(item);
        }
        //HttpContext.Session.Remove("UserId");
        //HttpContext.Session.Remove("UserName");
        //HttpContext.Session.Remove("UserRoles");
        //HttpContext.Session.Remove("UserEmail"); 
        return RedirectToAction("Index", "Home");
    }
}
