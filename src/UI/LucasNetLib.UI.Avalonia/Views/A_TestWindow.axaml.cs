using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace LucasNetLib.UI.Avalonia;

public partial class A_TestWindow : Window
{
    public A_TestWindow()
    {
        InitializeComponent();
        Canvas canvas = new Canvas();
        DockPanel dockPanel = new DockPanel();
        Grid grid = new Grid();
        RelativePanel relativePanel = new RelativePanel();
        StackPanel stackPanel = new StackPanel();
        WrapPanel wrapPanel = new WrapPanel();
        SplitView splitView = new SplitView();
    }
}