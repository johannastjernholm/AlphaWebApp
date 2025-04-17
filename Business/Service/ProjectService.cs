using Business.Models;
using Business.Factories;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Business.Service;

public class ProjectService
{
    private readonly AppDbContext _context;
    private readonly ProjectFactory _factory;

    public ProjectService(AppDbContext context, ProjectFactory factory)
    {
        _context = context;
        _factory = factory;
    }

    /// <summary>
    /// Lägg till projekt i databasen.
    /// </summary>   
    public async Task AddProjectAsync(ProjectViewModel model)
    {
        //Använd factory för att skapa en entitet av det vi får in från formuläret
        var entity = _factory.Create(model);

        _context.Projects.Add(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Hämta alla projekt från databasen.
    /// </summary>
    /// <returns>Mappa entiteterna till modeller och visar de i listan.</returns>
    public async Task<List<ProjectViewModel>> GetAllProjectsAsync()
    {
        var projects = await _context.Projects.ToListAsync();

        return projects.Select(p => _factory.Create(p)).ToList();
    }
    /// <summary>
    /// Hämta alla projekt per status på projektet(status:not started, in progress, completed)
    /// </summary
    public async Task<List<ProjectViewModel>> GetProjectsByStatusAsync(string status)
    {
        var projects = await _context.Projects
            .Where(p => p.Status == status)
            .ToListAsync();

        return projects
            .Select(p => _factory.Create(p))
            .ToList();
    }

    /// <summary>
    /// Hämta projekt med id
    /// </summary>
    public async Task<ProjectViewModel?> GetProjectsByIdAsync(int id)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        if (entity == null)
        {
            return null;
        }
        return _factory.Create(entity);

    }
    /// <summary>
    /// Uppdatera ett befintligt projekt(på id)
    /// </summary>
    
    public async Task UpdateProjectAsync(int id, ProjectViewModel projectViewModel)
    {
        var entity = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        if(entity == null)
        {
            return;
        }

        entity.ProjectName = projectViewModel.ProjectName;
        entity.ClientName = projectViewModel.ClientName;
        entity.Description = projectViewModel.Description;
        entity.StartDate = projectViewModel.StartDate!.Value;
        entity.EndDate = projectViewModel.EndDate;
        entity.Budget = projectViewModel.Budget;
        entity.Status = projectViewModel.Status;

        await _context.SaveChangesAsync();
    }
}
