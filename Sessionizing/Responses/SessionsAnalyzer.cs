namespace sessionizer.Responses;

public class SessionsAnalyzer 
{
    public SessionsAnalyzer(Dictionary<string, List<double>> urlsSessionsMap)
    {
        UrlsSessionsMap = urlsSessionsMap;
    }

    public Dictionary<string, List<double>> UrlsSessionsMap { get; set; }
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
    public  bool IsUrlExists(string siteUrl)
    {
        return UrlsSessionsMap.ContainsKey(siteUrl);
    }


}