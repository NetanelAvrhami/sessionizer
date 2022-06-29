using sessionizer.Models;
using sessionizer.Responses;

namespace sessionizer.Loaders;

public class SessionsLoadData : ILoadData<SessionsAnalyzer>
{
    private SessionsAnalyzer? _loadedData;
    private readonly Dictionary<SessionKey, SessionTwo> _lastTimeStampByUserAndSite;
    
    public SessionsLoadData()
    {
        _lastTimeStampByUserAndSite = new Dictionary<SessionKey, SessionTwo>();
    }

    public SessionsAnalyzer LoadToDataStructure(List<TableRecord> records)
    {
        if (_loadedData != null)
        {
            return _loadedData;
        }
        _loadedData = new SessionsAnalyzer();
        foreach (var tableRecord in records)
        {
            var sessionKey = new SessionKey(tableRecord.SiteUrl, tableRecord.UserId);
            if (_lastTimeStampByUserAndSite.ContainsKey(sessionKey))
            {
                var currentSession = _lastTimeStampByUserAndSite[sessionKey];
                if (currentSession.EndTime + 60000 * 30 < tableRecord.Timestamp)
                {
                    var sessionDuration = currentSession.EndTime - currentSession.StartTime;
                    _loadedData.AddNewSession(tableRecord.SiteUrl,sessionDuration);
                    currentSession.StartTime = tableRecord.Timestamp;
                }
                currentSession.EndTime = tableRecord.Timestamp;
            }
            else
            {
                _lastTimeStampByUserAndSite.Add((sessionKey),
                    new SessionTwo(tableRecord.Timestamp));
            }
        }

        foreach (var (key, value) in _lastTimeStampByUserAndSite)
        {
            var sessionDuration = value.EndTime - value.StartTime;
            if (value.EndTime == -1)
            {
                sessionDuration = 0;
            }
            _loadedData.AddNewSession(key.SiteUrl,sessionDuration);
        }
        return _loadedData;
    }
}