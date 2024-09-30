using Microsoft.AspNetCore.Mvc;

namespace Blubb.Users.Api.Controllers;

[Route("/users/")]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Route("test")]
    public IActionResult Test()
    {
        return Ok("Hello World");
    }
}