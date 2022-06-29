namespace sessionizer.Models;

public class TableRecord
{
    private TableRecord(string userId, string siteUrl, string pageViewUrl, DateTime visitDateTime)
    {
        UserId = userId;
        SiteUrl = siteUrl;
        PageViewUrl = pageViewUrl;
        VisitDateTime = visitDateTime;
    }

    public string UserId { get; }
    public string SiteUrl { get; }
    public string PageViewUrl { get; }
    public DateTime VisitDateTime { get; }

    public static TableRecord ConvertToTableRecord(string record)
    {
        var split = record.Split(',');
        return new TableRecord(split[0].Split('_')[1]
            , split[1]
            , split[2]
            , new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Convert.ToDouble(split[3])));
    }
}