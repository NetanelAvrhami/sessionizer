using sessionizer.Loaders;
using sessionizer.Responses;
using sessionizer.Utilities;

namespace sessionizer;

public class Bootstrap
{

    private bool _initialized;
    private readonly object _lock = new();
    private SessionsAnalyzer? _sessionsAnalyzer;
    private UsersAnalyzer? _usersAnalyzer;
    private readonly ILoadSessionsData _loadSessionsData;
    private readonly ILoadUserData _loadUserData;
    private readonly IFileReader _fileReader;



    public Bootstrap(IFileReader fileReader, ILoadSessionsData loadSessionsData, ILoadUserData loadUserData)
    {
        _fileReader = fileReader;
        _loadSessionsData = loadSessionsData;
        _loadUserData = loadUserData;
    }
    
    public SessionsAnalyzer? GetSessionAnalyzer(){
        Init();
        return _sessionsAnalyzer;
    }
    
    public UsersAnalyzer? GetUserAnalyzer(){
        Init();
        return _usersAnalyzer;
    }
    
    public void Init(){
        if(_initialized) return;
        
        lock (_lock)
        {
            if(_initialized){
                return;
            }
            var allRecords = _fileReader.ReadFile("Data/example.csv");
            _sessionsAnalyzer = _loadSessionsData.LoadUsersSites(allRecords);
            _usersAnalyzer = _loadUserData.LoadSessions(allRecords);
            _initialized = true;
        }

    }
}