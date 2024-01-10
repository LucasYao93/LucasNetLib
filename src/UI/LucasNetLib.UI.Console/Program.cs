using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole();

//builder.Services.AddHostedService<SampleTimerHostService>();
using IHost host = builder.Build();

await host.RunAsync();