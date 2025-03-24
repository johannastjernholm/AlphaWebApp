using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers;
[Route("projects")]
public class ProjectsController : Controller
{
    [Route("")]
    public IActionResult Projects()
    {
        return View();
    }
}
