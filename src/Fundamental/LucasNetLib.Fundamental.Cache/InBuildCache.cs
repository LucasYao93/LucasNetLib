using System.Runtime.Caching;

/// <summary>
/// .Net内建的Cache
/// </summary>
public class InBuildCache01
{
    static void Main01()
    {
        ObjectCache cache = MemoryCache.Default;
        string fileContents = cache["filecontents"] as string;
        CacheItemPolicy policy = new CacheItemPolicy();

        if (fileContents == null)
        {
            //List<string> filePaths = new List<string>();
            //filePaths.Add(@"D:\cache.txt");

            //policy.ChangeMonitors.Add(new
            //HostFileChangeMonitor(filePaths));

            // Fetch the file contents.
            //fileContents =
            //    File.ReadAllText(@"D:\cache.txt");
            // Fetch the file contents.
            fileContents = "test";
            policy.UpdateCallback = UpdateCacheCallback;

            cache.Set("filecontents", fileContents, policy);
        }

        while (true)
        {
            // 等待用户按下一个键
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            Console.WriteLine(Environment.NewLine);

            // 如果用户按下Ctrl+C，则停止循环
            if ((keyInfo.Key == ConsoleKey.C) && (keyInfo.Modifiers == ConsoleModifiers.Control))
            {
                break;
            }
            cache.Set("filecontents", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), policy);

            Console.WriteLine(cache.Get("filecontents"));
        }
    }


    // 缓存项被移除时的回调方法
    static void UpdateCacheCallback(CacheEntryUpdateArguments arguments)
    {
        Console.WriteLine("缓存项被更新：");
        Console.WriteLine("键：" + arguments.UpdatedCacheItem.Key);
        Console.WriteLine("值：" + arguments.UpdatedCacheItem.Value);
        Console.WriteLine("原因：" + arguments.RemovedReason);
    }
}

public class InBuildCache02
{

    static void Main()
    {

    }
}

public class NaiveCache<TItem>
{
    Dictionary<object, TItem> _cache = new Dictionary<object, TItem>();
    public TItem GetOrCreate(object key, Func<TItem> createItem)
    {
        if (!_cache.ContainsKey(key))
        { _cache[key] = createItem(); }
        return _cache[key];
    }
}