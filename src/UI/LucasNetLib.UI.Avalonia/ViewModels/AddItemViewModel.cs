using Avalonia;
using ReactiveUI;
using System.Reactive;
using LucasNetLib.UI.Avalonia.DataModel;

namespace LucasNetLib.UI.Avalonia.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        private string _Description = string.Empty;

        public ReactiveCommand<Unit, ToDoItem> OkCommand { get; }

        public ReactiveCommand<Unit, Unit> CancelCommand { get; }

        public AddItemViewModel()
        {
            var isValidObservable = this.WhenAnyValue(
                x => x.Description, 
                x => !string.IsNullOrWhiteSpace(x)
                );

            OkCommand = ReactiveCommand.Create(
                () => new ToDoItem { Description = Description },
                isValidObservable
                );

            CancelCommand = ReactiveCommand.Create(() => { });
        }

        public string Description
        {
            get => _Description;
            set => this.RaiseAndSetIfChanged(ref _Description, value);
        }
    }
}
