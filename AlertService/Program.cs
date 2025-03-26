namespace TestDome;

class AlertService
{
    public AlertService(IAlertDAO alertDAO)
    {
        _storage = alertDAO;
    }

    private readonly IAlertDAO _storage;

    public Guid RaiseAlert()
    {
        return this._storage.AddAlert(DateTime.Now);
    }

    public DateTime GetAlertTime(Guid id)
    {
        return this._storage.GetAlert(id);
    }


    static void Main(string[] args)
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
    private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();

    public Guid AddAlert(DateTime time)
    {
        Guid id = Guid.NewGuid();
        this.alerts.Add(id, time);
        return id;
    }

    public DateTime GetAlert(Guid id)
    {
        return this.alerts[id];
    }
}

/*

Refactor the **AlertService** and **AlertDAO** classes:

- Create a new interface, named **IAlertDAO**, that contains the same methods as **AlertDAO**.
- **AlertDAO** should implement the **IAlertDAO** interface.
- **AlertService** should have a public constructor that accepts **IAlertDAO**.
- The **RaiseAlert** and **GetAlertTime** methods should use the object passed through the constructor.

*/
