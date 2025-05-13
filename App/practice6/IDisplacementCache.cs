namespace App.practice6;

public interface IDisplacementCache<T>
{
    int Capacity { get; set; }
    TimeSpan Ttl { get; set; }
    ITimeService TimeService { get; }

    IReadOnlyDictionary<string, T> GetAllCacheItems();
    void AddOrUpdate(string key, T item);
    T TryGet(string key);
    void ClearExpiredItems();
}