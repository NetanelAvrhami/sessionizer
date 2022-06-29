using Microsoft.AspNetCore.Mvc;
using sessionizer.Loaders;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[Route("/api/users")]
public class UsersController : ControllerBase
{
    [HttpGet("numOfSites/{userId}")]
    public ActionResult<string> GetUserUniqueSites([FromRoute] string userId)
    {
        //https://localhost:7162/api/users/numOfSites/visitor_6267
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var userLoader = new UsersLoadData();
        var data = userLoader.LoadToDataStructure(file);
        var count = data.GetVisitorUniqueSites(userId);
        return Ok("yes");

    }
}