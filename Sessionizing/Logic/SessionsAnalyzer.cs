namespace sessionizer.Logic;

public class SessionsAnalyzer
{
    private Dictionary<string, List<double>> UrlsSessionsMap { get; }

    public SessionsAnalyzer(Dictionary<string, List<double>> urlsSessionsMap)
    {
        UrlsSessionsMap = urlsSessionsMap;
    }

    public int? GetNumberOfSessions(string siteUrl)
    {
        if (UrlsSessionsMap.ContainsKey(siteUrl))
            return UrlsSessionsMap[siteUrl].Count;
        return null;
    }

    public List<double> GetSessionsMedianLength(string siteUrl)
    {
        var sessionsSize = UrlsSessionsMap[siteUrl].Count;
        UrlsSessionsMap[siteUrl].Sort();
        return UrlsSessionsMap[siteUrl];
        // return (sessionsSize % 2 == 0) ? ((UrlsSessionsMap[siteUrl][sessionsSize / 2] + 
        //                                    (UrlsSessionsMap[siteUrl][(sessionsSize / 2) - 1]))) 
        //     : (UrlsSessionsMap[siteUrl][(sessionsSize - 1) / 2]);
    }
}