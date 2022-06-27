using Microsoft.AspNetCore.Mvc;
using sessionizer.Logic;
using sessionizer.Responses;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[Route("/api/users")]
public class UsersController : ControllerBase
{
    [HttpGet("sites/{userId}")]
    public ActionResult<string> GetUserSites([FromRoute] string userId)
    {
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var userLoader = new UsersLoader();
        var data = userLoader.LoadData(file);
        var userLogic = new UsersLogic();
        return UsersLogic.IsUserExists(data, userId)
            ? Ok("Number Of Unique sites visied of " + userId+ " is " +userLogic.GetNumberOfUniqueVisitedSite(data, userId))
            : NotFound("User " + userId + "Is not listed in the DB");
    }
}