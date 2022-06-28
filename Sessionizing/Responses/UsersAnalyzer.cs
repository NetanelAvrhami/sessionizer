namespace sessionizer.Responses;

public class UsersAnalyzer
{
    private readonly Dictionary<string, HashSet<string>> _usersUniqueSitesMap;

    public UsersAnalyzer(Dictionary<string, HashSet<string>> usersUniqueSitesMap)
    {
        _usersUniqueSitesMap = usersUniqueSitesMap;
    }

    public int GetNumberOfUniqueVisitedSite(string userId)
    {
        return _usersUniqueSitesMap[userId].Count;
    }

    public bool IsUserExists(string userId)
    {
        return _usersUniqueSitesMap.ContainsKey(userId);
    }
}