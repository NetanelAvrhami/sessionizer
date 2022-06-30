using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public class LoadSessionsData : ILoadSessionsData
{
    public SessionsAnalyzer LoadSessions(List<VisitRecord> visits)
    {
        var lastSessionByUserAndSite = new Dictionary<SessionKey, Session>();
        var urlsSessionsMap = new Dictionary<string, List<double>>();

        foreach (var visit in visits)
        {
            var sessionKey = new SessionKey(visit.SiteUrl, visit.UserId);
            if (lastSessionByUserAndSite.ContainsKey(sessionKey))
            {
                var openedSession = lastSessionByUserAndSite[sessionKey];
                if (openedSession.EndTime.AddMinutes(30) < visit.VisitTime)
                {
                    var sessionDuration = openedSession.EndTime.Subtract(openedSession.StartTime).TotalSeconds;
                    if (!urlsSessionsMap.ContainsKey(visit.SiteUrl))
                        urlsSessionsMap[visit.SiteUrl] = new List<double>();
                    urlsSessionsMap[visit.SiteUrl].Add(sessionDuration);
                    openedSession.StartTime = visit.VisitTime;
                }

                openedSession.EndTime = visit.VisitTime;
            }
            else
            {
                lastSessionByUserAndSite.Add((sessionKey),
                    new Session(visit.VisitTime));
            }
        }

        foreach (var (siteAndUrl, session) in lastSessionByUserAndSite)
        {
            var sessionDuration = session.EndTime.Subtract(session.StartTime).TotalSeconds;
            if (!urlsSessionsMap.ContainsKey(siteAndUrl.SiteUrl))
                urlsSessionsMap[siteAndUrl.SiteUrl] = new List<double>();
            urlsSessionsMap[siteAndUrl.SiteUrl].Add(sessionDuration);
        }

        return new SessionsAnalyzer(urlsSessionsMap);
    }
}