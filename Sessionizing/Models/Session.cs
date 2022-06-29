namespace sessionizer.Models;

public class Session
{
    public Session(Guid sessionId, double timeStamp, double duration)
    {
        SessionId = sessionId;
        TimeStamp = timeStamp;
        Duration = duration;
    }

    public Guid SessionId { get; set; }
    private double TimeStamp { get; set; }
    public double Duration { get; set; }
    
}