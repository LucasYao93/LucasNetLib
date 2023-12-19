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