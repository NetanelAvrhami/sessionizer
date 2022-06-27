using sessionizer.Loaders;
using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer;

public class SessionsLoader : ILoader<SessionsResponse>
{
    public SessionsResponse LoadData(List<TableRecord> records)
    {
       var lastTimeStampByUserAndSite = new Dictionary<(string, string), double>();
       var urlsSessions = new Dictionary<string, List<double>>();
       foreach (var tableRecord in records)
       {
           if (!urlsSessions.ContainsKey(tableRecord.SiteUrl))
           {
               urlsSessions[tableRecord.SiteUrl] = new List<double>();
           }
           if (lastTimeStampByUserAndSite.ContainsKey((tableRecord.UserId, tableRecord.SiteUrl)))
           {
               var lastTimeStamp = lastTimeStampByUserAndSite[(tableRecord.UserId, tableRecord.SiteUrl)];
               var lastTimestampAfterParse = TableRecord.ConvertFromTimestampToDate(Convert.ToDouble(lastTimeStamp));
               var sessionLength = 0.0;
               var currentTimeStampAfterParse =
                   TableRecord.ConvertFromTimestampToDate(Convert.ToDouble(tableRecord.Timestamp));
               if (currentTimeStampAfterParse <= lastTimestampAfterParse.AddMinutes(30)) // 30 min didnt pass
               {
                   sessionLength = Convert.ToDouble(currentTimeStampAfterParse.Subtract(lastTimestampAfterParse)
                       .TotalSeconds);
                   urlsSessions[tableRecord.SiteUrl].Remove(urlsSessions[tableRecord.SiteUrl].First(length => length == 0)); 
                   urlsSessions[tableRecord.SiteUrl].Add(sessionLength);
               }
               else
               {
                   urlsSessions[tableRecord.SiteUrl].Add(sessionLength);
               }
           }
           else
           {
               urlsSessions[tableRecord.SiteUrl].Add(0); // single page
           }
           lastTimeStampByUserAndSite[(tableRecord.UserId, tableRecord.SiteUrl)] = tableRecord.Timestamp;
       }
       return new SessionsResponse
       {
           UrlsSessionsMap = urlsSessions
       };
    }
}