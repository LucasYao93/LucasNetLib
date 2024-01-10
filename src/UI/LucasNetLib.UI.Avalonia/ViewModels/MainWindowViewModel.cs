using ReactiveUI;
using System;
using System.Reactive.Linq;
using LucasNetLib.UI.Avalonia.DataModel;
using LucasNetLib.UI.Avalonia.Services;
using LucasNetLib.UI.Avalonia.Repository;
using LucasNetLib.UI.Avalonia.Views;

namespace LucasNetLib.UI.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{

    private ViewModelBase _ContentViewModel;

    public MainWindowViewModel()
    {
        DBFressSql.SyncStructure();

        DBFressSql.InitTableDataAsync().GetAwaiter().GetResult();

        var service = new ToDoListService();
        
        ToDoList = new ToDoListViewModel(service.GetItemsAsync().GetAwaiter().GetResult());
        SimpleChangeMessage = new SimpleChangeMessageViewModel();
        CommandUpdateMessage = new CommandUpdateMessageViewModel();
        ReactiveCommandView = new ReactiveCommandViewModel();

        _ContentViewModel = ToDoList;
    }

    public ViewModelBase ContentViewModel { 
        get { 
            return _ContentViewModel; 
        }
        private set => this.RaiseAndSetIfChanged(ref _ContentViewModel, value);
    }

    public ToDoListViewModel ToDoList { get; }

    public SimpleChangeMessageViewModel SimpleChangeMessage { get; }

    public CommandUpdateMessageViewModel CommandUpdateMessage { get; }

    public ReactiveCommandViewModel ReactiveCommandView { get; }

    public void AddItem()
    {
        AddItemViewModel addItemViewModel = new AddItemViewModel();

        Observable.Merge(
                addItemViewModel.OkCommand,
                addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
                .Take(1)
                .Subscribe(newItem =>
                {
                    if (newItem != null)
                    {
                        ToDoList.ListItems.Add(newItem);
                    }
                    ContentViewModel = ToDoList;
                });

        ContentViewModel = addItemViewModel;

    }
}
