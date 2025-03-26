namespace TestDome;

internal class AlertService
{
    private readonly IAlertDAO _storage;

    public AlertService(IAlertDAO alertDAO)
    {
        _storage = alertDAO;
    }

    public Guid RaiseAlert()
    {
        return _storage.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return _storage.GetAlert(id);
    }


    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public interface IAlertDAO
{
    Guid AddAlert(DateTime time);
    DateTime GetAlert(Guid id);
}

public class AlertDAO : IAlertDAO
{
    private readonly Dictionary<Guid, DateTime> alerts = new();

    public Guid AddAlert(DateTime time)
    {
        var id = Guid.NewGuid();
        alerts.Add(id, time);
        return id;
    }

    public DateTime GetAlert(Guid id)
    {
        return alerts[id];
    }
}

/*

Refactor the **AlertService** and **AlertDAO** classes:

- Create a new interface, named **IAlertDAO**, that contains the same methods as **AlertDAO**.
- **AlertDAO** should implement the **IAlertDAO** interface.
- **AlertService** should have a public constructor that accepts **IAlertDAO**.
- The **RaiseAlert** and **GetAlertTime** methods should use the object passed through the constructor.

*/
