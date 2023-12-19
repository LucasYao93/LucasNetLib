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