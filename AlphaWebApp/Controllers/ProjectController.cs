using AlphaWebApp.Business.Models;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers;
[Route("projects")]
public class ProjectController(AppDbContext context) : Controller
{
    private readonly AppDbContext _context = context;

    [Route("")]
    public IActionResult Projects()
    {
        return View();
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ProjectViewModel project)
    {
        if (ModelState.IsValid)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return RedirectToAction("Projects");
        }
        return View(project);
    }

}
