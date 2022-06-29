namespace sessionizer.Models;

public class SessionKey
{
    public string SiteUrl { get; }
    private string UserId { get; }

    public SessionKey(string siteUrl, string userId)
    {
        SiteUrl = siteUrl;
        UserId = userId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SiteUrl, UserId);
    }

    public override bool Equals(object? obj)
    {
        // If parameter is null return false.
        if (obj == null)
        {
            return false;
        }

        // If parameter cannot be cast to Point return false.
        if (obj is not SessionKey p)
        {
            return false;
        }

        return (SiteUrl == p.SiteUrl) && (UserId == p.UserId);
    }
}