using Microsoft.AspNetCore.Mvc;
using sessionizer.Loaders;
using sessionizer.Logic;
using sessionizer.Responses;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[ApiController]
[Route("/api/sessions")]
public class SessionsController : ControllerBase
{
    
    

    [HttpGet("total/{sessionUrl}")]
    public int GetNumberOfSessions([FromRoute] string sessionUrl)
    {
        //https://localhost:7162/api/sessions/total/www.s_7.com
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var sessionLoader = new SessionsLoader();
        var sessionsLogic = new SessionsLogic();
        return 1;
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