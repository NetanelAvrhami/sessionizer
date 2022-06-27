using sessionizer.Responses;

namespace sessionizer.Logic;

public class SessionsLogic : ISessionsLogic
{
    public int GetNumberOfSessions(SessionsResponse sessionsResponse, string siteUrl)
    {
        return sessionsResponse.UrlsSessionsMap[siteUrl].Count;
    }

    public double GetSessionsMedianLength(SessionsResponse sessionsResponse, string siteUrl)
    {
        var sessionsSize = sessionsResponse.UrlsSessionsMap[siteUrl].Count;
        sessionsResponse.UrlsSessionsMap[siteUrl].Sort();
        return (sessionsSize % 2 == 0) ? ((sessionsResponse.UrlsSessionsMap[siteUrl][sessionsSize / 2] + 
                                          (sessionsResponse.UrlsSessionsMap[siteUrl][(sessionsSize / 2) - 1]))) 
            : (sessionsResponse.UrlsSessionsMap[siteUrl][(sessionsSize - 1) / 2]);
    }
    public static bool IsUrlExists(SessionsResponse sessionsResponse, string siteUrl)
    {
        return sessionsResponse.UrlsSessionsMap.ContainsKey(siteUrl);
    }
}