// using sessionizer.Models;
// using System.Linq;
//
//
// namespace sessionizer.Loaders;
//
// public class DataProcessing
// {
//     public int GetSessions(IEnumerable<TableRecord> tableRecords, string siteUrl)
//     {
//         var siteSessions = new List<Session>();
//         var visitedSitesByVisitor = tableRecords.Where(r => r.SiteUrl == siteUrl)
//             .GroupBy(r => r.UserId)
//             .ToDictionary(g => g.Key, g =>
//             {
//                 var a = g.OrderBy(s => s.Timestamp).ToList();
//                 return calculateSessions(a, out var sessionId);
//             });
//         var sum = visitedSitesByVisitor.Sum(e => e.Value.Count);
//         // .Select(r => new
//             // {
//             //     user = r.Key,
//             //     value = r.Value
//             // }).ToList();
//
//
//             // foreach (var userVisits in visitedSitesByVisitor)
//         // {
//         //     foreach (var tableRecord in userVisits)
//         //     {
//         //         tableRecord.
//         //     }
//         // }
//         
//         return 1; // select all visits of each user who visited 'siteUrl'
//
//
//
//     }
//
//     private List<Session> calculateSessions(List<TableRecord> visits)
//     {
//         var sessionId = Guid.NewGuid();
//         var sessions = new List<Session>();
//         var firstTimeStamp = visits[0].Timestamp;
//         visits.Skip(1);
//         return sessions;
//         
//         
//     }
//    
// }