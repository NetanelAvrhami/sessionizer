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
            var firstFileRecord = _fileReader.ReadFile(Consts.FirstFile);
            var secondFileRecord = _fileReader.ReadFile(Consts.SecondFile);
            var thirdFileRecord = _fileReader.ReadFile(Consts.ThirdFile);
            var mergedRecords = ListUtils.MergeTwo(firstFileRecord, secondFileRecord);
            mergedRecords = ListUtils.MergeTwo(mergedRecords, thirdFileRecord);
            _sessionsAnalyzer = _sessionsLoader.LoadSessions(mergedRecords);
            _usersAnalyzer = _usersLoader.LoadUsersSites(mergedRecords);
            _initialized = true;
        }

    }
}