using Microsoft.AspNetCore.Mvc;

namespace NZWalks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllStudents()
    {
        string []studentsNames = {"John", "Mark", "Luke"};
        return Ok(studentsNames);
    }
}
