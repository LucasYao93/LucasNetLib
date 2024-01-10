//using LucasNetLib.Fundamental.Common;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;


//public class SampleTimerHostService : AbstractHostedService
//{
//    public System.Threading.Timer SampleTimer { get; private set; }
//    public SampleTimerHostService(
//        ILogger<SampleTimerHostService> logger,
//        IHostApplicationLifetime appLifetime
//        ) : base(logger, appLifetime) 
//    {
//        SampleTimer = new Timer((obj) => { Logger.LogInformation("Timer running"); }, this, 1000, 3000);
//    }


//    public override async Task StartAsync(CancellationToken cancellationToken)
//    {
//        await base.StartAsync(cancellationToken);
//    }

//    public override async Task StopAsync(CancellationToken cancellationToken)
//    {
//        await base.StopAsync(cancellationToken);   
//    }
//}