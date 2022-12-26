public interface IObserver
{
    void OnNotify(string ev, params object[] args);
}
