using Microsoft.AspNetCore.Mvc;
using sessionizer.Logic;
using sessionizer.Responses;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[ApiController]
[Route("/api/sessions")]
public class SessionsController : ControllerBase
{
    

    [HttpGet("total/{sessionUrl}")]
    public int GetSessionsNumber([FromRoute] string sessionUrl)
    {
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var sessionLoader = new SessionsLoader();
        var sessionsLogic = new SessionsLogic();
        return sessionsLogic.GetNumberOfSessions(sessionLoader.LoadData(file),sessionUrl);
    }
    [HttpGet("median/{sessionUrl}")]
    public double GetSessionMedianLength([FromRoute] string sessionUrl)
    {
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var sessionLoader = new SessionsLoader();
        var sessionsLogic = new SessionsLogic();
        return sessionsLogic.GetSessionsMedianLength(sessionLoader.LoadData(file),sessionUrl);
    }
}