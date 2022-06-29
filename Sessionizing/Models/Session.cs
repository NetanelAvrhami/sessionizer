namespace sessionizer.Models;

public class Session
{
    public Session(double startTime, double? endTime = null)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public double StartTime { get; set; }
    public double? EndTime { get; set; }
    
}