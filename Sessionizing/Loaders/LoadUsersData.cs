using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public class LoadUsersData : ILoadUserData
{
    private UsersAnalyzer? _loadedData;

    public UsersAnalyzer? LoadUsersSites(List<TableRecord> records)
    {
        if (_loadedData != null)
        {
            return _loadedData;
        }
        _loadedData = new UsersAnalyzer();
        foreach (var tableRecord in records)
        {
            _loadedData.AddSiteForUser(tableRecord.UserId,tableRecord.SiteUrl);
        }
        return _loadedData;
    }


}