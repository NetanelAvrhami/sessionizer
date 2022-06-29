using Microsoft.AspNetCore.Mvc;
using sessionizer.Loaders;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[ApiController]
[Route("/api/sessions")]
public class SessionsController : ControllerBase
{
    
    

    [HttpGet("total/{siteUrl}")]
    public int GetNumberOfSessions([FromRoute] string siteUrl)
    {
        //https://localhost:7162/api/sessions/total/www.s_7.com
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var proceccing = new LoadSessionsData();
        var res = proceccing.LoadToDataStructure(file);
        return res.GetNumberOfSessions(siteUrl); 
    }
    [HttpGet("median/{siteUrl}")]
    public void GetSessionMedianLength([FromRoute] string siteUrl)
    {
        var file = FileReader.ConvertCsvToTableRecord("Data/example.csv");
        var sessionLoader = new LoadSessionsData();
    }
}