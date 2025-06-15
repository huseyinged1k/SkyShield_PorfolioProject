using System.Collections.Generic;

public class LogSubject
{
    private List<ILogObserver> observers = new List<ILogObserver>();

    public void Register(ILogObserver observer)
    {
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var o in observers)
            o.OnLogEvent(message);
    }
}