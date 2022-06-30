using sessionizer.Loaders;
using sessionizer.Logic;
using sessionizer.Utilities;

namespace sessionizer;

public class Bootstrap
{

    private bool _initialized;
    private readonly object _lock = new();
    private SessionsAnalyzer? _sessionsAnalyzer;
    private UsersAnalyzer? _usersAnalyzer;
    private readonly ILoadSessionsData _sessionsLoader;
    private readonly ILoadUserData _usersLoader;
    private readonly IFileReader _fileReader;



    public Bootstrap(IFileReader fileReader, ILoadSessionsData sessionsLoader, ILoadUserData usersLoader)
    {
        _fileReader = fileReader;
        _sessionsLoader = sessionsLoader;
        _usersLoader = usersLoader;
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
            var allRecords = _fileReader.ReadFile("Data/input_1.csv");
            var allRecords2 = _fileReader.ReadFile("Data/input_2.csv");
            var allRecords3 = _fileReader.ReadFile("Data/input_3.csv");
            var merged = Merge.MergeTwo(allRecords, allRecords2);
            merged = Merge.MergeTwo(merged, allRecords3);
            _sessionsAnalyzer = _sessionsLoader.LoadSessions(merged);
            _usersAnalyzer = _usersLoader.LoadUsersSites(merged);
            _initialized = true;
        }

    }
}