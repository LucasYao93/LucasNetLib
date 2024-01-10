using Microsoft.Extensions.Logging;

internal interface IExampleService
{
    void DoSomeWork(int inc);
}

internal class ExampleService: IExampleService
{
    public readonly ILogger<ExampleService> Logger;
    private int _SUM = 0;
    public ExampleService(ILogger<ExampleService> logger)
    {
        Logger = logger;
    }
    public void DoSomeWork(int inc)
    {
        _SUM += inc;
        Logger.LogInformation("DoSomeWork was called. sum={sum}, inc={inc}", _SUM, inc);
    }
}

/* Example
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

IServiceCollection serviceCollection = new ServiceCollection();

serviceCollection.AddSingleton<IExampleService, ExampleService>();

serviceCollection.AddLogging(builder => builder.AddConsole());

IServiceProvider serviceProvide = serviceCollection.BuildServiceProvider();

var exampleService = serviceProvide.GetRequiredService<IExampleService>();

exampleService.DoSomeWork(10);

exampleService.DoSomeWork(20);

Console.ReadKey();
 */