namespace App.practice6;

public class DisplacementCache<T> : IDisplacementCache<T>
{

    public int Capacity { get; set; }
    public TimeSpan Ttl { get; set; }
    public ITimeService TimeService { get; }
    
    private Dictionary<string, T> cache;
    private Dictionary<string, TimeSpan> ttls; 
    
    
    public DisplacementCache(ITimeService timeService, int capacity, TimeSpan ttl)
    {
        this.Capacity = capacity;
        this.TimeService = timeService;
        this.Ttl = ttl;
        cache = new Dictionary<string, T>();
        ttls = new Dictionary<string, TimeSpan>();
    }
    
    public IReadOnlyDictionary<string, T> GetAllCacheItems()
    {
        return cache;
    }

    public void AddOrUpdate(string key, T item)
    {
        if (cache.ContainsKey(key))
        {   
            cache[key] = item;
            ttls[key] = TimeService.GetNowTime().TimeOfDay;
            return;
        }

        if (cache.Count == Capacity)
        {
            ClearExpiredItems();

            if (cache.Count == Capacity)
            {
                DeleteTheOldest();
            }
        }
        
        TimeSpan curTime = TimeService.GetNowTime().TimeOfDay;
        cache[key] = item;
        ttls[key] = curTime;
    }

    private void DeleteTheOldest()
    {
        string key = cache.Keys.First();
        TimeSpan maxTtl = TimeSpan.MinValue;

        
        
        foreach (KeyValuePair<string, TimeSpan> ttl in ttls)
        {
            if (ttl.Value > maxTtl)
            {
                maxTtl = ttl.Value; 
                key = ttl.Key;
            }
        }
        
        
        cache.Remove(key);
        ttls.Remove(key);
    }
    
    public T TryGet(string key)
    {
        if (cache.ContainsKey(key))
        {
            ttls[key] = TimeService.GetNowTime().TimeOfDay;
            return cache[key];
        }
        
        return default(T);
    }

    public void ClearExpiredItems()
    {
        TimeSpan curTime = TimeService.GetNowTime().TimeOfDay;
        List<string> keysToRemove = new List<string>();

        foreach (var ttl in ttls)
        {
            if (curTime - ttl.Value >= Ttl)
            {
                keysToRemove.Add(ttl.Key);   
            }
        }

        foreach (var key in keysToRemove)
        {
            cache.Remove(key);
            ttls.Remove(key);
        }
    }
}