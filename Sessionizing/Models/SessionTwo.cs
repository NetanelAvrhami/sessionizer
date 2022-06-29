namespace sessionizer.Models;

public class SessionTwo
{
    public long StartTime { get; set; }
    public long EndTime { get; set; }
    public SessionTwo(long startTime)
    {
        this.EndTime = startTime;
        this.StartTime = startTime;
    }

}