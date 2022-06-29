using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public interface ILoadSessionsData
{
    public SessionsAnalyzer? LoadSessions(List<TableRecord> records);

}