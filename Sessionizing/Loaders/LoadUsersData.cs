using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public class LoadUsersData : ILoadUserData
{
    public UsersAnalyzer LoadUsersSites(List<TableRecord> records)
    {
        var usersUniqueSitesMap = new Dictionary<string, HashSet<string>>();
        foreach (var tableRecord in records)
        {
            if (!usersUniqueSitesMap.ContainsKey(tableRecord.UserId))
            {
                usersUniqueSitesMap.Add(tableRecord.UserId, new HashSet<string>());
            }

            usersUniqueSitesMap[tableRecord.UserId].Add(tableRecord.SiteUrl);
        }

        return new UsersAnalyzer(usersUniqueSitesMap);
    }
}