namespace sessionizer.Models;

public class TableRecord : IComparable<TableRecord>
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

    public static DateTime ConvertFromTimestampToDate(double timestamp)
    {
        var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(timestamp);
    }

    public static TableRecord ConvertToTableRecord(string record)
    {
        var split = record.Split(',');
        return new TableRecord(split[0],split[1],split[2],Convert.ToInt64(split[3]));
    }

    
    public int CompareTo(TableRecord? other)
    {
        if (other != null) return this.Timestamp.CompareTo(other.Timestamp);
        return 1;
    }
}