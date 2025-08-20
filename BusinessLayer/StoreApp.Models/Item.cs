using StoreApp.Models.Base;

namespace StoreApp.Models;
public class Item : BusinessModel<Item>
{
    private string _name = string.Empty;
    private decimal _price;
    private decimal _quantity;
    private decimal _amount;
    private int _unitId;
    private int _locationId;
    private Unit? _unit = default!;
    private Location? _location = default!;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public decimal Price
    {
        get => _price;
        set => SetProperty(ref _price, value);
    }

    public decimal Quantity
    {
        get => _quantity;
        set => SetProperty(ref _quantity, value);
    }

    public decimal Amount
    {
        get => _amount;
        set => SetProperty(ref _amount, value);
    }

    public int UnitId
    {
        get => _unitId;
        set => SetProperty(ref _unitId, value);
    }

    public int LocationId
    {
        get => _locationId;
        set => SetProperty(ref _locationId, value);
    }

    public override bool Validate(Mode mode)
    {
        bool retVal = base.Validate(mode);
        if (mode == Mode.Insert || mode == Mode.Update)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddError(nameof(Name), "Name cannot be empty.");
                retVal = false;
            }
            if (Price < 0)
            {
                AddError(nameof(Price), "Price cannot be negative.");
                retVal = false;
            }
            if (Quantity < 0)
            {
                AddError(nameof(Quantity), "Quantity cannot be negative.");
                retVal = false;
            }
            if (UnitId <= 0)
            {
                AddError(nameof(UnitId), "Unit must be selected.");
                retVal = false;
            }
            else if (mode == Mode.Delete)
            {
                if (Id <= 0)
                {
                    AddError(nameof(Id), "Id must be greater than zero.");
                    retVal = false;
                }
            }
        }
        return retVal;
    }
    // Navigation properties
    public Unit? Unit
    {
        get => _unit;
        set => SetProperty(ref _unit, value);
    }
    public Location? Location
    {
        get => _location;
        set => SetProperty(ref _location, value);
    }

    public static implicit operator Item(Dal.Entities.ItemEntity entity)
    {
        if (entity == null) return null!;
        return new Item
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Quantity = entity.Quantity,
            Amount = entity.Amount,
            UnitId = entity.UnitId,
            LocationId = entity.LocationId,
            Unit = entity.Unit is null ? null : (Unit)entity.Unit,
            Location = entity.Location is null ? null : (Location)entity.Location,
        };
    }

    public static implicit operator Dal.Entities.ItemEntity(Item item)
    {
        if (item == null) return null!;
        return new Dal.Entities.ItemEntity
        {
            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            Quantity = item.Quantity,
            Amount = item.Amount,
            UnitId = item.UnitId,
            LocationId = item.LocationId,
        };
    }
}
