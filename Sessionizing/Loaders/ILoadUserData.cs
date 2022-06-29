using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public interface ILoadUserData
{
    public UsersAnalyzer? LoadUsersSites(List<TableRecord> records);

}