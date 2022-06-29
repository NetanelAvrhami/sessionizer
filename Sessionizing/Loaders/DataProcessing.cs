using sessionizer.Models;
using System.Linq;


namespace sessionizer.Loaders;

public class DataProcessing
{
    public int GetSessions(IEnumerable<TableRecord> tableRecords, string siteUrl)
    {
        var siteSessions = new List<TableRecord>();
        var visitedSitesByVisitor = tableRecords.Where(r => r.SiteUrl == siteUrl)
            .GroupBy(r => r.UserId).ToDictionary(g => g.Key, g =>
            {
                var a = g.OrderBy(s => s.Timestamp).ToList();
                return calculateSessions(a).GroupBy(x=>x.SessionId);
            });
        return visitedSitesByVisitor.Values.Count;

    }

    private List<Session> calculateSessions(List<TableRecord> t)
    {
        var sessionsList = new List<Session>();
        var sessionId = Guid.NewGuid();
        var sessionStart = t[0].Timestamp;
        var prevTimeStamp = sessionStart;
        foreach (var t1 in t)
        {
            var sessionDuration = t1.Timestamp - sessionStart;
            if (t1.Timestamp - prevTimeStamp > 60 * 30)
            {
                sessionId = new Guid();
                sessionStart = t1.Timestamp;
                sessionDuration = 0;
            }

            prevTimeStamp = t1.Timestamp;
            sessionsList.Add(new Session(sessionId,t1.Timestamp,sessionDuration));
        }

        var a=   sessionsList.GroupBy(s => s.SessionId).Select(e=> new
        {
            S = e.GetEnumerator().Current.Duration
        });
        return sessionsList;


    }



}