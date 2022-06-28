using Microsoft.AspNetCore.Mvc;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[Route("/api/users")]
public class UsersController : ControllerBase
{
    [HttpGet("sites/{userId}")]
    public ActionResult<string> GetUserUniqueSites([FromRoute] string userId)
    {
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var userLoader = new UsersLoader();
        var data = userLoader.LoadData(file);

    }
}