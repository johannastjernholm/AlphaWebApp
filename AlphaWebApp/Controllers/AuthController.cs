using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers;

[Route("auth")]
public class AuthController(UserManager<ApplicationUser> userManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;

    [HttpGet("register")]
    public IActionResult Register()
    {
       return View();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(registerViewModel);
        }
        var user = new ApplicationUser
        {
            UserName = registerViewModel.Email,
            Email = registerViewModel.Email
        };

        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if(result.Succeeded) {
            return RedirectToAction("Login");
        }

        foreach(var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(registerViewModel);
    }
}
