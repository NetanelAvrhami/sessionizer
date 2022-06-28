
namespace sessionizer.Models;

public class Session
{

    private readonly Dictionary<string, List<double>> _urlsSessionsMap;
    private readonly Dictionary<(string, string), double> _lastTimeStampByUserAndSite;


    public Session(Dictionary<(string, string), double> lastTimeStampByUserAndSite)
    {
        _urlsSessionsMap = new Dictionary<string, List<double>>();
        _lastTimeStampByUserAndSite = lastTimeStampByUserAndSite;
    }

    public void AddSession(string siteUrl, double length)
    {
        if (!_urlsSessionsMap.ContainsKey(siteUrl))
        {
            _urlsSessionsMap.Add(siteUrl, new List<double>());
        }

        _urlsSessionsMap[siteUrl].Add(length);
    }

    public void UpdateSessions(TableRecord tableRecord)
    {
        if (_lastTimeStampByUserAndSite.ContainsKey((tableRecord.UserId, tableRecord.SiteUrl)))
        {
            
        }



    }
}