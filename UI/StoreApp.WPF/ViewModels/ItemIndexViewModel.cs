using StoreApp.HttpHandler;
using StoreApp.Models;
using StoreApp.WPF.RelayCommands;
using StoreApp.WPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApp.WPF.ViewModels;

public class ItemIndexViewModel : ObservableObject
{
    private readonly ItemHttpService _itemHttpService;

    public ItemIndexViewModel(ItemHttpService itemHttpService)
    {
        _itemHttpService = itemHttpService;
        LoadItemsCommand = new RelayCommand(async () => await LoadItemsAsync());
        _ = LoadItemsAsync(); // Load items automatically when ViewModel is created
    }

    public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();

    public ICommand LoadItemsCommand { get; }

    private async Task LoadItemsAsync()
    {
        var items = await _itemHttpService.GetAllAsync("Item");
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
}