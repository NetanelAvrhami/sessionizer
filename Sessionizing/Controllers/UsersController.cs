using Microsoft.AspNetCore.Mvc;
using sessionizer.Loaders;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[Route("/api/users")]
public class UsersController : ControllerBase
{
    private Bootstrap _bootstrap;
    public UsersController(Bootstrap bootstrap)
    {
        _bootstrap = bootstrap;
    }
    [HttpGet("numOfSites/{userId}")]
    public ActionResult<string> GetUserUniqueSites([FromRoute] string userId)
    {
        //https://localhost:7162/api/users/numOfSites/visitor_6267
        // var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        // var userLoader = new UsersLoadData();
        // var data = userLoader.LoadToDataStructure("bla");
        // var count = data.GetVisitorUniqueSites(userId);
        var res = _bootstrap.GetUserAnalyzer()?.GetVisitorUniqueSites(userId);
        return Ok(res);

    }
}