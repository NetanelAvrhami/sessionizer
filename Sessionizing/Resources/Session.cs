namespace sessionizer.Resources;

public class Session
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Session(DateTime startTime)
    {
        StartTime = startTime;
        EndTime = startTime;
    }
}