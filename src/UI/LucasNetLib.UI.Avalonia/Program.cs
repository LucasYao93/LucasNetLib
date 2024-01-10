using Autofac;
using Avalonia;
using Avalonia.ReactiveUI;
using Avalonia.ReactiveUI.Splat;
using LucasNetLib.UI.Avalonia.Repository;
using LucasNetLib.UI.Avalonia.ViewModels;
using LucasNetLib.UI.Avalonia.Views;
using System;

namespace LucasNetLib.UI.Avalonia;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI()
            .UseReactiveUIWithAutofac((container) => { });
}
