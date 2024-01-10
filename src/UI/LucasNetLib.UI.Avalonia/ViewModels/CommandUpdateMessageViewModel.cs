using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.UI.Avalonia.ViewModels
{
    public class CommandUpdateMessageViewModel: ViewModelBase
    {
        private string _message = "欢迎来的Avalonia";

        public string Message {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public void ButtonAction()
        {
            Message = "来自Avalonia的另一个问候";
        }
    }
}
