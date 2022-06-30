using sessionizer.Logic;
using sessionizer.Resources;

namespace sessionizer.Loaders;

public interface ILoadSessionsData
{
    public SessionsAnalyzer LoadSessions(List<VisitRecord> visits);
}