namespace sessionizer.Responses;

public class UsersAnalyzer
{
    private readonly Dictionary<string, HashSet<string>> _usersUniqueSitesMap;

    public UsersAnalyzer()
    {
        _usersUniqueSitesMap = new Dictionary<string, HashSet<string>>();
    }
    public int GetVisitorUniqueSites(string userId)
    {
        if(IsUserExists(userId))
            return _usersUniqueSitesMap[userId].Count;
        return -1;
    }
    public void AddSiteForUser(string userId, string siteUrl)
    {
        if (!IsUserExists(userId))
        {
            _usersUniqueSitesMap.Add(userId, new HashSet<string>());
        }

        _usersUniqueSitesMap[userId].Add(siteUrl);
    }
    private bool IsUserExists(string userId)
    {
        return _usersUniqueSitesMap.ContainsKey(userId);
    }
}