
namespace sessionizer.Models;

public class Session
{
    private static readonly Dictionary<string, HashSet<string>> UsersUniqueSitesMap =
        new Dictionary<string, HashSet<string>>();

    private static readonly Dictionary<(string, string), string> SessionsMap =
        new Dictionary<(string, string), string>();

    private static readonly Dictionary<string, List<double>> UrlsSessions = new Dictionary<string, List<double>>();

    private const string Input1 = "Data/example.csv";

    public static void CalculateUsersSite()
    {
        // var usersUniqueSitesMap = new Dictionary<string, HashSet<string>>();
        using var data = new StreamReader(Input1);
        string? input1CurrentLine;
        while ((input1CurrentLine = data.ReadLine()) != null)
        {
            var record = TableRecord.ConvertToTableRecord(input1CurrentLine);
            if (!UsersUniqueSitesMap.ContainsKey(record.UserId))
            {
                UsersUniqueSitesMap.Add(record.UserId, new HashSet<string>());
            }

            UsersUniqueSitesMap[record.UserId].Add(record.SiteUrl);
        }
    }

    public static void CalculateSessionsLength()
    {
        // using var input1 = new StreamReader(Input1);
        // string? input1CurrentLine;
        // while ((input1CurrentLine = input1.ReadLine()) != null)
        // {
        //     var record = TableRecord.ConvertToTableRecord(input1CurrentLine);
        //     if (SessionsMap.ContainsKey((record.UserId, record.SiteUrl)))
        //     {
        //         var lastTimeStamp = SessionsMap[(record.UserId, record.SiteUrl)];
        //         var lastTimestampAfterParse = TableRecord.ConvertFromTimestampToDate(Convert.ToDouble(lastTimeStamp));
        //         var currentTimeStampAfterParse =
        //             TableRecord.ConvertFromTimestampToDate(Convert.ToDouble(record.Timestamp));
        //         if (currentTimeStampAfterParse < lastTimestampAfterParse.AddMinutes(30)) // 30 min didnt pass
        //         {
        //             if (!UrlsSessions.ContainsKey(record.SiteUrl))
        //             {
        //                 UrlsSessions[record.SiteUrl] = new List<double>();
        //             }
        //
        //             UrlsSessions[record.SiteUrl]
        //                 .Add(Convert.ToDouble(currentTimeStampAfterParse.Subtract(lastTimestampAfterParse)
        //                     .TotalSeconds));
        //         }
        //     }
        //
        //     SessionsMap[(record.UserId, record.SiteUrl)] = record.Timestamp;
        // }
    }

    public static HashSet<string> GetUserUniqueSites(string userId)
    {
        return UsersUniqueSitesMap[userId];
    }
    public static int GetSiteNumberOfSessions(string siteUrl)
    {
        return UrlsSessions[siteUrl].Count;
    }


}
