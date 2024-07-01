using DMStorage.Core.Repositories;
using DMStorage.Core.Service;
using DMStorage.Core.ViewModels;
using DMStorage.Data;
using DMStorage.Helpers;
using DMStorage.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

[LoadUserRoles]
public class AdminController : Controller
{
    private IAccountService _accountService;
    public AdminController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public IActionResult ManageRoles()
    {
        var users = _accountService.GetUsers();
        var roles = _accountService.GetRoles();
        var model = new ManageRolesViewModel
        {
            Users = users,
            Roles = roles
        };
        return View(model);
    }

    [HttpPost]
    public JsonResult AssignRole(int userId, int roleId)
    {
        var user = _accountService.GetUser(userId);
        if (user != null)
        {
            _accountService.UpdateUser(userId, roleId);
            var updatedUser = _accountService.GetUser(userId);
            var rolename = _accountService.GetRole(updatedUser.RoleId);
            return Json(new { success = true, user = new { roleName = rolename } });
        }
        return Json(new { success = false, message = "Uzivatel nenalezen." });
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        try
        {
            _accountService.DeleteUser(id);
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }

        return Json(new { success = true });
    }
}
