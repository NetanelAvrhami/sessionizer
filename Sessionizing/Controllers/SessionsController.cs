using Microsoft.AspNetCore.Mvc;
using sessionizer.Loaders;
using sessionizer.Utilities;

namespace sessionizer.Controllers;

[ApiController]
[Route("/api/sessions")]
public class SessionsController : ControllerBase
{
    private readonly Bootstrap _bootstrap;
    public SessionsController(Bootstrap bootstrap)
    {
        _bootstrap = bootstrap;
    }
    

    [HttpGet("total/{siteUrl}")]
    public ActionResult<string> GetNumberOfSessions([FromRoute] string siteUrl)
    {
        //https://localhost:7162/api/sessions/total/www.s_7.com
        var sessionNum = _bootstrap.GetSessionAnalyzer()?.GetNumberOfSessions(siteUrl);
        return Ok(sessionNum);
    }
    [HttpGet("median/{siteUrl}")]
    public ActionResult<string> GetSessionMedianLength([FromRoute] string siteUrl)
    {
        var medianLength =  _bootstrap.GetSessionAnalyzer()?.GetSessionsMedianLength(siteUrl);
        return Ok(medianLength);
    }
}