namespace sessionizer.Models;

public class Session
{
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public Session(long startTime)
    {
        StartTime = startTime;
        EndTime = startTime;
    }

}