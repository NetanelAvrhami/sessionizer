namespace sessionizer.Models;

public class VisitRecord
{
    private VisitRecord(string userId, string siteUrl, string pageViewUrl, DateTime dateTime)
    {
        UserId = userId;
        SiteUrl = siteUrl;
        PageViewUrl = pageViewUrl;
        DateTime = dateTime;
    }

    public string UserId { get; }
    public string SiteUrl { get; }
    public string PageViewUrl { get; }
    public DateTime DateTime { get; }

    public static VisitRecord ConvertToVisitRecord(string record)
    {
        var cells = record.Split(',');
        return new VisitRecord(cells[0].Contains('_') ? cells[0].Split('_')[1] : cells[0]
            , cells[1]
            , cells[2]
            , new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(cells[3])));
    }
}