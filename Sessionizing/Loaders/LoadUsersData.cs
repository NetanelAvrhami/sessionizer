using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public class LoadUsersData : ILoadUserData
{
    public UsersAnalyzer LoadUsersSites(List<VisitRecord> visits)
    {
        var usersUniqueSitesMap = new Dictionary<string, HashSet<string>>();
        foreach (var visit in visits)
        {
            if (!usersUniqueSitesMap.ContainsKey(visit.UserId))
            {
                usersUniqueSitesMap.Add(visit.UserId, new HashSet<string>());
            }

            usersUniqueSitesMap[visit.UserId].Add(visit.SiteUrl);
        }

        return new UsersAnalyzer(usersUniqueSitesMap);
    }
}