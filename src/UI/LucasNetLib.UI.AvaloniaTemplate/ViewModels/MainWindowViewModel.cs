using LucasNetLib.UI.AvaloniaTemplate.CustomControls;
using ReactiveUI;

namespace LucasNetLib.UI.AvaloniaTemplate.ViewModels;

/// <summary>
/// Main window of the App.
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private ReactiveObject _ContentViewModel;

    public MainWindowViewModel()
    {
        _ContentViewModel = new MenuComponentControlViewModel()
        {
            Title = "第一个菜单"
        };
    }
    public ReactiveObject ContentViewModel
    {
        get
        {
            return _ContentViewModel;
        }
        private set
        {
            this.RaiseAndSetIfChanged(ref _ContentViewModel, value);
        }
    }
}
