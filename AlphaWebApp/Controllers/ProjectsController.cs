using Microsoft.AspNetCore.Mvc;

namespace AlphaWebApp.Controllers;

public class ProjectsController : Controller
{
    [Route("projects")]
    public IActionResult Projects()
    {
        return View();
    }
}
