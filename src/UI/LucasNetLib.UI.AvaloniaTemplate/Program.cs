using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Threading;

namespace LucasNetLib.UI.AvaloniaTemplate;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        const string mutexId = AppConst.AppName;

        using (var mutex = new Mutex(false, mutexId, out bool created))
        {
            //bool hasHandler = false;
            //try
            //{
            //    hasHandler = mutex.WaitOne(500, false);
                
            //}
            //catch (Exception ex)
            //{

            //}

            if (created)
            {
                // Apllication not exist
                BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
            } else
            {
                // Application has exist

            }
        }


    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
