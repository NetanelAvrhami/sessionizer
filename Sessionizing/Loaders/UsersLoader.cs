using sessionizer.Loaders;
using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer;

public class UsersLoader : ILoader<UsersAnalyzer>
{
    public UsersAnalyzer LoadData(List<TableRecord> records)
    {
        var uniqueSitesPerUser = new Dictionary<string, HashSet<string>>();
        foreach (var tableRecord in records)
        {
            if (!uniqueSitesPerUser.ContainsKey(tableRecord.UserId))
            {
                uniqueSitesPerUser.Add(tableRecord.UserId, new HashSet<string>());
            }
            uniqueSitesPerUser[tableRecord.UserId].Add(tableRecord.SiteUrl);
        }

        return new UsersAnalyzer(uniqueSitesPerUser);
    }


}