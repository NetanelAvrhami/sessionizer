using sessionizer.Logic;
using sessionizer.Models;

namespace sessionizer.Loaders;

public interface ILoadSessionsData
{
    public SessionsAnalyzer LoadSessions(List<VisitRecord> visits);
}