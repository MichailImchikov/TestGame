
public interface IObservable
{
    public void AddObserver(IObserver o);
    public void RemoveObserver(IObserver o);
    public void NotifyObservers(IActionClick action);
}
public interface IObserver
{
    public void UpdateAction(IActionClick action);
}

