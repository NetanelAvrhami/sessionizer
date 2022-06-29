using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public interface ILoadUserData
{
    public UsersAnalyzer? LoadSessions(List<TableRecord> records);

}