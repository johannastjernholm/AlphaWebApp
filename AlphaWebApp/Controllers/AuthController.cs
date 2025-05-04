using Business.Models;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
//Koden skriven i samarbete med AI
namespace AlphaWebApp.Controllers;

[Route("auth")]
public class AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : Controller
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

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
            Email = registerViewModel.Email,
            FullName = registerViewModel.FullName
        };

        var result = await _userManager.CreateAsync(user, registerViewModel.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Login");
        }

        foreach (var error in result.Errors)
        {
            Console.WriteLine($"Error: { error.Description}");
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(registerViewModel);
    }


    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(loginViewModel);
        }

        var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            return RedirectToAction("Projects", "Projects");
        }
        ModelState.AddModelError(string.Empty, "Invalid login attempt.");

        return View(loginViewModel);
    }
    [HttpPost("logout")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        Console.WriteLine("LOGOUT METHOD REACHED!");

        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}
