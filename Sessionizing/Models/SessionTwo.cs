namespace sessionizer.Models;

public class SessionTwo
{
    public SessionTwo(long startTime, long endTime)
    {
        this.endtime = endTime;
        this.startTime = startTime;
    }
    public SessionTwo(long startTime)
    {
        this.endtime = startTime;
        this.startTime = startTime;
    }
    public long startTime { get; set; }
    public long endtime { get; set; }
}