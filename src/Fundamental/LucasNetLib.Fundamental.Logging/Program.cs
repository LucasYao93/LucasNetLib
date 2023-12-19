using log4net;
using log4net.Config;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

public class Program
{

    static void Main(string[] args)
    {
        // Set up a simple configuration that logs on the console.
        var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
        //在Assembly添加配置配置信息[assembly: log4net.Config.XmlConfigurator(Watch=true)] 
        //LogManager.GetLogger(typeof(Program))会从在Assembly读取配置信息。
        XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config")); 

        BasicConfigurator.Configure();

        var serviceCollection = new ServiceCollection();
        
        serviceCollection.AddSingleton<Logger>();

        serviceCollection.AddSingleton<Bar>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var barService = serviceProvider.GetRequiredService<Bar>();

        barService.DoIt();

        Console.ReadKey();

    }
}

public class Bar
{
    private readonly Logger _Log;

    public Bar(Logger log)
    {
        _Log = log;
    }

    public void DoIt()
    {
        _Log.Information("Did it again!");
    }
}

public class Logger
{
    public readonly ILog _Log;

    public Logger()
    {
        _Log = LogManager.GetLogger(typeof(Program));
    }
    public void Information(object message)
    {
        _Log.Info(message);
    }
}