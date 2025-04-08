using System.ComponentModel.DataAnnotations;

namespace AlphaWebApp.Business.Models;

public class ProjectViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = " A project name is required.")]
    public string ProjectName { get; set; } = null!;

    [Required(ErrorMessage = "Client name is required.")]
    public string ClientName { get; set; } = null!;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    [Range(0.1, double.MaxValue, ErrorMessage ="Budget must be greater than 0.")]
    public decimal Budget { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; } = null!;
}
