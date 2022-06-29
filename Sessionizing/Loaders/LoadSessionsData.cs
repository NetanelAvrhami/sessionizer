using Microsoft.Extensions.DependencyInjection;
using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public class SessionsLoadData : ILoadData<SessionsAnalyzer>
{
    private SessionsAnalyzer? _loadedData;
    

    public SessionsAnalyzer LoadToDataStructure(List<TableRecord> records)
    {
        if (_loadedData != null)
        {
            return _loadedData;
        }

        var lastTimeStampByUserAndSite = new Dictionary<SessionKey, SessionTwo>();
        var urlsSessions = new Dictionary<string, List<long>>();
        foreach (var tableRecord in records)
        {
            var sessionKey = new SessionKey(tableRecord.SiteUrl, tableRecord.UserId);
            if (lastTimeStampByUserAndSite.ContainsKey(sessionKey))
            {
                var currentSession = lastTimeStampByUserAndSite[sessionKey];
                if (currentSession.endtime + 60000*30 < tableRecord.Timestamp)
                {
                    if (!urlsSessions.ContainsKey(tableRecord.SiteUrl))
                        urlsSessions[tableRecord.SiteUrl] = new List<long>();
                    urlsSessions[tableRecord.SiteUrl].Add(currentSession.endtime - currentSession.startTime);
                    currentSession.startTime = tableRecord.Timestamp;
                }
                currentSession.endtime = tableRecord.Timestamp;
            }
            else
            {
                lastTimeStampByUserAndSite.Add((sessionKey),
                    new SessionTwo(tableRecord.Timestamp));
            }
        }

        foreach (var (key, value) in lastTimeStampByUserAndSite)
        {
            if (!urlsSessions.ContainsKey(key.SiteUrl))
                urlsSessions[key.SiteUrl] = new List<long>();
            var sessionDuration = value.endtime - value.startTime;
            if (value.endtime == -1)
            {
                sessionDuration = 0;
            }

            urlsSessions[key.SiteUrl].Add(sessionDuration);
        }

        _loadedData = new SessionsAnalyzer(urlsSessions);
        return _loadedData;
    }
}