namespace sessionizer.Models;

public class SessionKey
{
    private (string, string) UserAndUrl;

    public SessionKey((string, string) userAndUrl)
    {
        UserAndUrl = userAndUrl;
    }
}