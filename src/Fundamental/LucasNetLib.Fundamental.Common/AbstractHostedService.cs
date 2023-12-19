using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LucasNetLib.Fundamental.Common
{
    /// <summary>
    /// Abstract HostService. All HostService should implement it.
    /// </summary>
    public abstract class AbstractHostedService : IHostedService
    {
        public readonly ILogger Logger;

        public AbstractHostedService(
            ILogger logger,
            IHostApplicationLifetime appLifetime
            )
        {
            Logger = logger;
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
        }

        public virtual async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("StartAsync has been called.");
            await Task.CompletedTask;
        }

        public virtual async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("StopAsync has been called.");
            await Task.CompletedTask;
        }

        public virtual void OnStarted()
        {
            Logger.LogInformation("OnStarted has been called.");
        }

        public virtual void OnStopping()
        {
            Logger.LogInformation("OnStopping has been called.");
        }

        public virtual void OnStopped()
        {
            Logger.LogInformation("OnStopped has been called.");
        }
    }
}
