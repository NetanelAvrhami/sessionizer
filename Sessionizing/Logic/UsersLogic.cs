using sessionizer.Responses;

namespace sessionizer.Logic;

public class UsersLogic : IUsersLogic
{
    public int GetNumberOfUniqueVisitedSite(UsersResponse usersResponse, string userId)
    {
        return usersResponse.UsersUniqueSitesMap[userId].Count;
    }

    public static bool IsUserExists(UsersResponse usersResponse, string userId)
    {
        return usersResponse.UsersUniqueSitesMap.ContainsKey(userId);
    }
}