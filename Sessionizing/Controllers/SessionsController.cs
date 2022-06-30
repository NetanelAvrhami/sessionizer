using Microsoft.AspNetCore.Mvc;


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
        var sessionsNum = _bootstrap.GetSessionAnalyzer()?.GetNumberOfSessions(siteUrl);
        if (sessionsNum != null)
            return Ok($"Site ${siteUrl} have ${sessionsNum} sessions");
        return NotFound($"Site #{siteUrl} is not listed in the db");
    }

    [HttpGet("median/{siteUrl}")]
    public ActionResult<string> GetSessionMedianLength([FromRoute] string siteUrl)
    {
        var medianLength = _bootstrap.GetSessionAnalyzer()?.GetSessionsMedianLength(siteUrl);
        return Ok(medianLength);
    }
}