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

        var lastTimeStampByUserAndSite = new Dictionary<(string, string), SessionTwo>();
        var urlsSessions = new Dictionary<string, List<long>>();
        foreach (var tableRecord in records)
        {
            if (lastTimeStampByUserAndSite.ContainsKey((tableRecord.UserId, tableRecord.SiteUrl)))
            {
                var currentSession = lastTimeStampByUserAndSite[(tableRecord.UserId, tableRecord.SiteUrl)];
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
                lastTimeStampByUserAndSite.Add((tableRecord.UserId, tableRecord.SiteUrl),
                    new SessionTwo(tableRecord.Timestamp));
            }
        }

        foreach (var keyValuePair in lastTimeStampByUserAndSite)
        {
            if (!urlsSessions.ContainsKey(keyValuePair.Key.Item2))
                urlsSessions[keyValuePair.Key.Item2] = new List<long>();
            var sessionDuration = keyValuePair.Value.endtime - keyValuePair.Value.startTime;
            if (keyValuePair.Value.endtime == -1)
            {
                sessionDuration = 0;
            }

            urlsSessions[keyValuePair.Key.Item2].Add(sessionDuration);
        }

        _loadedData = new SessionsAnalyzer(urlsSessions);
        return _loadedData;
    }
}