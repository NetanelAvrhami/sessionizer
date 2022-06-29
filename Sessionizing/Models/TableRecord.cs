namespace sessionizer.Models;

public class TableRecord 
{
    private TableRecord(string userId, string siteUrl, string pageViewUrl, long timestamp)
    {
        UserId = userId;
        SiteUrl = siteUrl;
        PageViewUrl = pageViewUrl;
        Timestamp = timestamp;
    }

    public string UserId { get; set; }
    public string SiteUrl { get; set; }
    public string PageViewUrl { get; set; }
    public long Timestamp { get; set; }
    
    public static TableRecord ConvertToTableRecord(string record)
    {
        var split = record.Split(',');
        return new TableRecord(split[0],split[1],split[2],Convert.ToInt64(split[3]));
    }

}