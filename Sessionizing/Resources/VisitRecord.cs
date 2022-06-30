namespace sessionizer.Resources;

public class VisitRecord
{
    public VisitRecord(string userId, string siteUrl, string pageViewUrl, DateTime visitTime)
    {
        UserId = userId;
        SiteUrl = siteUrl;
        PageViewUrl = pageViewUrl;
        VisitTime = visitTime;
    }

    public string UserId { get; set; }
    public string SiteUrl { get; set; }
    public string PageViewUrl { get; set; }
    public DateTime VisitTime { get; set; }
}