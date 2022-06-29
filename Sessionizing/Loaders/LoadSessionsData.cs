using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public class LoadSessionsData : ILoadSessionsData
{
    public SessionsAnalyzer LoadSessions(List<VisitRecord> visits)
    {
        var lastTimeStampByUserAndSite = new Dictionary<SessionKey, Session>();
        var urlsSessionsMap = new Dictionary<string, List<double>>();

        foreach (var visit in visits)
        {
            var sessionKey = new SessionKey(visit.SiteUrl, visit.UserId);
            if (lastTimeStampByUserAndSite.ContainsKey(sessionKey))
            {
                var currentSession = lastTimeStampByUserAndSite[sessionKey];
                if (currentSession.EndTime.AddMinutes(30) < visit.DateTime)
                {
                    var sessionDuration = currentSession.EndTime.Subtract(currentSession.StartTime).TotalSeconds;
                    if (!urlsSessionsMap.ContainsKey(visit.SiteUrl))
                        urlsSessionsMap[visit.SiteUrl] = new List<double>();
                    urlsSessionsMap[visit.SiteUrl].Add(sessionDuration);
                    currentSession.StartTime = visit.DateTime;
                }

                currentSession.EndTime = visit.DateTime;
            }
            else
            {
                lastTimeStampByUserAndSite.Add((sessionKey),
                    new Session(visit.DateTime));
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