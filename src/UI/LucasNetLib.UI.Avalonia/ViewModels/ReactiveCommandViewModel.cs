using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace LucasNetLib.UI.Avalonia.ViewModels
{
    public class ReactiveCommandViewModel : ViewModelBase
    {
        private string _UserName = string.Empty;

        public string UserName { 
            get => _UserName; 
            set => this.RaiseAndSetIfChanged(ref _UserName, value); 
        }

        public ReactiveCommand<Unit, Unit> SubmitCommand { get; }

        public ReactiveCommandViewModel()
        {
            IObservable<bool> isInputValid = this.WhenAnyValue(
                x => x.UserName,
                x => !string.IsNullOrWhiteSpace(x) && x.Length > 7
                );
            SubmitCommand = ReactiveCommand.Create(() =>
            {
                Debug.WriteLine("The submit command was run");
            }, isInputValid);
        }
    }
}
