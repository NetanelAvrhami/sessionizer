using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public class LoadSessionsData : ILoadSessionsData
{
    public SessionsAnalyzer LoadSessions(List<TableRecord> records)
    {
        var lastTimeStampByUserAndSite = new Dictionary<SessionKey, Session>();
        var urlsSessionsMap = new Dictionary<string, List<double>>();

        foreach (var tableRecord in records)
        {
            var sessionKey = new SessionKey(tableRecord.SiteUrl, tableRecord.UserId);
            if (lastTimeStampByUserAndSite.ContainsKey(sessionKey))
            {
                var currentSession = lastTimeStampByUserAndSite[sessionKey];
                if (currentSession.EndTime.AddMinutes(30) < tableRecord.VisitDateTime)
                {
                    var sessionDuration = currentSession.EndTime.Subtract(currentSession.StartTime).TotalSeconds;
                    if (!urlsSessionsMap.ContainsKey(tableRecord.SiteUrl))
                        urlsSessionsMap[tableRecord.SiteUrl] = new List<double>();
                    urlsSessionsMap[tableRecord.SiteUrl].Add(sessionDuration);
                    currentSession.StartTime = tableRecord.VisitDateTime;
                }

                currentSession.EndTime = tableRecord.VisitDateTime;
            }
            else
            {
                lastTimeStampByUserAndSite.Add((sessionKey),
                    new Session(tableRecord.VisitDateTime));
            }
        }

        foreach (var (siteAndUrl, session) in lastTimeStampByUserAndSite)
        {
            var sessionDuration = session.EndTime.Subtract(session.StartTime).TotalSeconds;
            if (!urlsSessionsMap.ContainsKey(siteAndUrl.SiteUrl))
                urlsSessionsMap[siteAndUrl.SiteUrl] = new List<double>();
            urlsSessionsMap[siteAndUrl.SiteUrl].Add(sessionDuration);
        }

        return new SessionsAnalyzer(urlsSessionsMap);
    }
}