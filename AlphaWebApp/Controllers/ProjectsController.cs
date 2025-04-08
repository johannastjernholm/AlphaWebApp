using AlphaWebApp.Business.Models;
using Business.Factories;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers;
[Route("projects")]
public class ProjectsController(AppDbContext context, ProjectFactory projectFactory) : Controller
{
    private readonly AppDbContext _context = context;
    private readonly ProjectFactory _projectFactory = projectFactory;

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
    public async Task<IActionResult> Create(ProjectViewModel projectViewModel)
    {
        if (ModelState.IsValid)
        {
            var entity = _projectFactory.Create(projectViewModel);
            _context.Projects.Add(entity);

            await _context.SaveChangesAsync();
            return RedirectToAction("Projects");
        }
        return View(projectViewModel);
    }

}
