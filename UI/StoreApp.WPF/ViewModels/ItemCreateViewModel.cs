using StoreApp.HttpHandler;
using StoreApp.Models;
using StoreApp.Models.Base;
using StoreApp.WPF.RelayCommands;
using StoreApp.WPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StoreApp.WPF.ViewModels;

public class ItemCreateViewModel : ObservableObject
{
    private readonly ItemHttpService _itemHttpService;
    private readonly UnitHttpService _unitHttpService;
    private readonly LocationHttpService _locationHttpService;
    private Item _item;

    public ItemCreateViewModel(ItemHttpService itemHttpService, UnitHttpService unitHttpService, LocationHttpService locationHttpService)
    {
        _itemHttpService = itemHttpService;
        _unitHttpService = unitHttpService;
        _locationHttpService = locationHttpService;
        _item = new Item();

        CreateCommand = new RelayCommand(async () => await CreateItemAsync());
        //BackCommand = new RelayCommand(() => OnBackRequested?.Invoke());

        _ = LoadDropdownDataAsync();
    }

    public Item Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    private void SetProperty(ref Item item, Item value)
    {
        throw new NotImplementedException();
    }

    public ObservableCollection<Unit> Units { get; } = new ObservableCollection<Unit>();
    public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();

    public ICommand CreateCommand { get; }
    public ICommand BackCommand { get; }

    public event Action? OnBackRequested;
    public event Action? OnItemCreated;

    private async Task LoadDropdownDataAsync()
    {
        var units = await _unitHttpService.GetAllAsync("Unit");
        var locations = await _locationHttpService.GetAllAsync("Location");

        Units.Clear();
        foreach (var unit in units)
        {
            Units.Add(unit);
        }

        Locations.Clear();
        foreach (var location in locations)
        {
            Locations.Add(location);
        }
    }

    private async Task CreateItemAsync()
    {
        // Fully qualify Mode if necessary, e.g., StoreApp.Models.Mode.Insert
        if (Item.Validate(Mode.Insert))
        {
            object value = await _itemHttpService.PostAsync("Item", Item);
            OnItemCreated?.Invoke();
        }
    }
}