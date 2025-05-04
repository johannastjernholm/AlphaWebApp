using System.ComponentModel.DataAnnotations;
//Kod skriven i samarbete med AI
namespace Business.Models;

public class RegisterViewModel
{
    [Required]

    public string FullName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password does not match")]
    public string ConfirmPassword { get; set; } = null!;
}
