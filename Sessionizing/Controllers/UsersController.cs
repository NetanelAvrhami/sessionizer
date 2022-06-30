using Microsoft.AspNetCore.Mvc;

namespace sessionizer.Controllers;

[Route("/api/users")]
public class UsersController : ControllerBase
{
    private readonly Bootstrap _bootstrap;

    public UsersController(Bootstrap bootstrap)
    {
        _bootstrap = bootstrap;
    }

    [HttpGet("numOfSites/{userId}")]
    public ActionResult<string> GetUserUniqueSites([FromRoute] string userId)
    {
        var numOfSites = _bootstrap.GetUserAnalyzer()?.GetVisitorUniqueSites(userId);
        if (numOfSites != null)
            return Ok($"User {userId} has visited {numOfSites} unique sites");
        return NotFound($"User {userId} is not listed in the db");
    }
}