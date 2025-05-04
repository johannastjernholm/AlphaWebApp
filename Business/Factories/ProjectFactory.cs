using Business.Models;
using Data.Entities;
//Kod skriven i samarbete med AI

namespace Business.Factories;

//Mappa entitet till viewmodel och viewmodel till entitet.

public class ProjectFactory
{
    public ProjectEntity Create(ProjectViewModel model)
    {
        return new ProjectEntity
        {
            ProjectName = model.ProjectName,
            ClientName = model.ClientName,
            Description = model.Description,
            StartDate = model.StartDate!.Value,
            EndDate = model.EndDate,
            Budget = model.Budget,
            Status = model.Status
        };
    }

    public ProjectViewModel Create(ProjectEntity entity)
    {
        return new ProjectViewModel
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            ClientName = entity.ClientName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            Status = entity.Status
        };
    }
}
