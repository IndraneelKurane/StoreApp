using StoreApp.HttpHandler;
using StoreApp.Models;
using StoreApp.WPF.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApp.WPF.ViewModels;

public class ItemIndexViewModel : ObservableObject
{
    private readonly ItemHttpService _itemHttpService;

    public ItemIndexViewModel(ItemHttpService itemHttpService)
    {
        _itemHttpService = itemHttpService;
        LoadItemsCommand = new RelayCommand(async _ => await LoadItemsAsync());
        NewCommand = new RelayCommand(async _ => await NewItemAsync());
        //EditCommand = new RelayCommand(async () => await EditItemAsync(), () => Item != null);
        _ = LoadItemsAsync(); // Load items automatically when ViewModel is created
    }


    public ObservableCollection<Item> Items { get; } = new ObservableCollection<Item>();
    public Item Item { get; private set; } = new Item();

    public ICommand LoadItemsCommand { get; }
    public ICommand NewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public event Action? OnNewRequested;

    private async Task LoadItemsAsync()
    {
        var items = await _itemHttpService.GetAllAsync("Item");
        Items.Clear();
        foreach (var item in items)
        {
            Items.Add(item);
        }
    }
    private async Task NewItemAsync()
    {
        Item = new Item();
        //await Task.CompletedTask;
    }
    //private async Task EditItemAsync(Item item)
    //{
    //    var items = await _itemHttpService.GetAllAsync("Item");
    //}
}