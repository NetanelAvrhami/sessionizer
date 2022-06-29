using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public interface ILoadUserData
{
    public UsersAnalyzer LoadUsersSites(List<TableRecord> records);
}