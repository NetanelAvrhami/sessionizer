namespace sessionizer.Logic;

public class UsersAnalyzer
{
    private readonly Dictionary<string, HashSet<string>> _usersUniqueSitesMap;

    public UsersAnalyzer(Dictionary<string, HashSet<string>> usersUniqueSitesMap)
    {
        _usersUniqueSitesMap = usersUniqueSitesMap;
    }

    public int GetVisitorUniqueSites(string userId)
    {
        return _usersUniqueSitesMap[userId].Count;
    }
}