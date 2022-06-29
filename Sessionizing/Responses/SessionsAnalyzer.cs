namespace sessionizer.Responses;

public class SessionsAnalyzer 
{
    private Dictionary<string, List<long>> UrlsSessionsMap { get; set; }
    
    public SessionsAnalyzer()
    {
        UrlsSessionsMap = new Dictionary<string,List<long>>();
    }

    public int GetNumberOfSessions(string siteUrl)
    {
         return UrlsSessionsMap[siteUrl].Count;
    }

    public double GetSessionsMedianLength(string siteUrl)
    {
        var sessionsSize = UrlsSessionsMap[siteUrl].Count;
         UrlsSessionsMap[siteUrl].Sort();
        return (sessionsSize % 2 == 0) ? ((UrlsSessionsMap[siteUrl][sessionsSize / 2] + 
                                           (UrlsSessionsMap[siteUrl][(sessionsSize / 2) - 1]))) 
            : (UrlsSessionsMap[siteUrl][(sessionsSize - 1) / 2]);
    }

    public void AddNewSession(string siteUrl, long sessionDuration)
    {
        if (!IsUrlExists(siteUrl))
            UrlsSessionsMap[siteUrl] = new List<long>();
        UrlsSessionsMap[siteUrl].Add(sessionDuration);
    }
    private bool IsUrlExists(string siteUrl)
    {
        return UrlsSessionsMap.ContainsKey(siteUrl);
    }




}