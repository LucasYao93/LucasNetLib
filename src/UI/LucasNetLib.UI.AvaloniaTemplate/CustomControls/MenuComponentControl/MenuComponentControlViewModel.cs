using Avalonia.Interactivity;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.UI.AvaloniaTemplate.CustomControls
{
    public class MenuComponentControlViewModel : ReactiveObject
    {
        private string _Title = string.Empty;
        public string Title
        {
            get => _Title;
            set => this.RaiseAndSetIfChanged(ref _Title, value);
        }

        public void OpenPage()
        {
        }
    }
}
