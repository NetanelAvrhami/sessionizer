using sessionizer.Responses;

namespace sessionizer.Logic;

public interface ISessionsLogic
{
    public int GetNumberOfSessions(SessionsResponse sessionsResponse, string siteUrl);
    public double GetSessionsMedianLength(SessionsResponse sessionsResponse, string siteUrl);
}