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
                return calculateSessions(a);
            });
        // var sum = visitedSitesByVisitor.Sum(e => e.Value.Count);
        // .Select(r => new
            // {
            //     user = r.Key,
            //     value = r.Value
            // }).ToList();


            // foreach (var userVisits in visitedSitesByVisitor)
        // {
        //     foreach (var tableRecord in userVisits)
        //     {
        //         tableRecord.
        //     }
        // }
        
        return 1; // select all visits of each user who visited 'siteUrl'



    }

    private List<Session> calculateSessions(List<TableRecord> t)
    {
        var sesssionsList = new List<Session>();
        var sessionId = Guid.NewGuid();
        var sessionStart = t[0].Timestamp;
        var prevTimeStamp = sessionStart;
        var s = new Session(t[0].Timestamp);

        foreach (var tableRecord in t)
        {
            s.EndTime = tableRecord.Timestamp;
            if (tableRecord.Timestamp - prevTimeStamp > 60 * 30)
            {
                sesssionsList.Add(new Session(sessionStart,prevTimeStamp));
                sessionId = new Guid();
                sessionStart = tableRecord.Timestamp;
            }

            prevTimeStamp = tableRecord.Timestamp;
        }
        
//         session_id += 1
//         session_start = site_visitor_visits.iloc[0].timestamp
//         prev_timestamp = session_start
//         for visit in site_visitor_visits.iterrows():
//         session_duration = visit[1].timestamp - session_start
//
// # If prev visit occured more than 30 min ago, start new session
//         if visit[1].timestamp - prev_timestamp > 60 * 30:
//         session_id += 1
//         session_start = visit[1].timestamp
//         session_duration = 0
//             
//         prev_timestamp = visit[1].timestamp
//             
// # add the result to a simple list
//         sessions.append((visit[1].site_url, visit[1].visitor_id,
//             session_id, visit[1].timestamp, session_duration))

    }



}