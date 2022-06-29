using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public interface ILoadSessionsData
{
    public SessionsAnalyzer? LoadUsersSites(List<TableRecord> records);

}