namespace sessionizer.Models;

public class TableRecord : IComparable<TableRecord>
{
    public string UserId { get; set; }
    public string SiteUrl { get; set; }
    public string PageViewUrl { get; set; }
    public double Timestamp { get; set; }

    public static DateTime ConvertFromTimestampToDate(double timestamp)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return origin.AddSeconds(timestamp);
    }

    public static TableRecord ConvertToTableRecord(string record)
    {
        var tableRecord = new TableRecord();
        string?[] split = record.Split(',');
        tableRecord.UserId = split[0];
        tableRecord.SiteUrl = split[1];
        tableRecord.PageViewUrl = split[2];
        tableRecord.Timestamp = Convert.ToDouble(split[3]);
        return tableRecord;
    }

    
    public int CompareTo(TableRecord other)
    {
         return this.Timestamp.CompareTo(other.Timestamp);
    }
}