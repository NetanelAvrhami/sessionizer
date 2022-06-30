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

    public double? GetSessionsMedianLength(string siteUrl)
    {
        if (!UrlsSessionsMap.ContainsKey(siteUrl))
            return null;

        var sessionsSize = UrlsSessionsMap[siteUrl].Count;
        UrlsSessionsMap[siteUrl].Sort();
        var sessionList = UrlsSessionsMap[siteUrl];
        var midIndex = sessionsSize / 2;
        if (sessionsSize % 2 != 0)
            return sessionList[midIndex];

        var value1 = sessionList[midIndex];
        var value2 = sessionList[midIndex - 1];
        return (value1 + value2) / 2;
    }
}