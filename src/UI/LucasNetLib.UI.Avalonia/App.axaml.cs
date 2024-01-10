using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using LucasNetLib.UI.Avalonia.ViewModels;
using LucasNetLib.UI.Avalonia.Views;
using Splat;
using System;

namespace LucasNetLib.UI.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {

            desktop.MainWindow = new A_TestWindow
            {
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}