using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{

    // https://localhost:7081/api/Students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string[] students = new string[] { "Ahsan", "Arslan", "Farhan", "Hamza", "Hassan" };
            return Ok(students);

        }
    }
}
