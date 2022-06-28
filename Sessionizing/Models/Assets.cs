namespace sessionizer.Models;

public class Assets
{
    private readonly Dictionary<string, HashSet<string>> _uniqueSitesPerUser;
    
    public Assets()
    {
        _uniqueSitesPerUser = new Dictionary<string, HashSet<string>>();
    }

    public void AddAsset(string userId, string siteUrl)
    {
        if (!_uniqueSitesPerUser.ContainsKey(userId))
        {
            _uniqueSitesPerUser.Add(userId, new HashSet<string>());
        }
        _uniqueSitesPerUser[userId].Add(siteUrl);
    }
    public bool IsUserExists(string userId)
    {
        return _uniqueSitesPerUser.ContainsKey(userId);
    }
    public int GetNumberOfUniqueVisitedSite(string userId)
    {
        return _uniqueSitesPerUser[userId].Count;
    }
}