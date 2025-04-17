using Business.Models;
using Business.Factories;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Business.Service;
using System.Threading.Tasks;

namespace AlphaWebApp.Controllers;
[Route("projects")]
public class ProjectsController(AppDbContext context, ProjectFactory projectFactory, ProjectService projectService) : Controller
{
    private readonly AppDbContext _context = context;
    private readonly ProjectFactory _projectFactory = projectFactory;
    private readonly ProjectService _projectService = projectService;

    [Route("")]
    public async Task<IActionResult> Projects()
    {
        ViewBag.Filter = "All";
        var projects = await _projectService.GetAllProjectsAsync();
        return View(projects);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter(string status)
    {
        var filteredProjects = await _projectService.GetProjectsByStatusAsync(status);
        ViewBag.Filter = status;
        return View("Projects", filteredProjects);
    }


    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new ProjectViewModel());
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _projectService.GetProjectsByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
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
