
using StoreApp.Models.Base;

namespace StoreApp.Models;
public class LocationRow : BusinessModel<LocationRow>
{
    private string _name = string.Empty;
    private bool _inUse = false;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public bool InUse
    {
        get => _inUse;
        set => SetProperty(ref _inUse, value);
    }

    public static implicit operator LocationRow(Dal.Entities.LocationRowEntity entity)
    {
        if (entity == null) return null!;
        return new LocationRow
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
    public static implicit operator Dal.Entities.LocationRowEntity(LocationRow locationRow)
    {
        if (locationRow == null) return null!;
        return new Dal.Entities.LocationRowEntity
        {
            Id = locationRow.Id,
            Name = locationRow.Name,
        };
    }
}
