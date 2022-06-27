
using sessionizer.Responses;

namespace sessionizer.Logic;

public interface IUsersLogic
{
    public int GetNumberOfUniqueVisitedSite(UsersResponse usersResponse,string siteUrl);
}