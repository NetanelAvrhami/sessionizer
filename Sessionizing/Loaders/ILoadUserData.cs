using sessionizer.Logic;
using sessionizer.Resources;

namespace sessionizer.Loaders;

public interface ILoadUserData
{
    public UsersAnalyzer LoadUsersSites(List<VisitRecord> visits);
}