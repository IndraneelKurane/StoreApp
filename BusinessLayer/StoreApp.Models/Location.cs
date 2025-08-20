using StoreApp.Models.Base;

namespace StoreApp.Models;
public class Location : BusinessModel<Location>
{
    private string _name = string.Empty;
    private int _locationRowId;
    private int _rackNo;
    private DateTime _startedUsingOn;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public int LocationRowId
    {
        get => _locationRowId;
        set => SetProperty(ref _locationRowId, value);
    }

    public int RackNo
    {
        get => _rackNo;
        set => SetProperty(ref _rackNo, value);
    }

    public DateTime StartedUsingOn
    {
        get => _startedUsingOn;
        set => SetProperty(ref _startedUsingOn, value);
    }

    public override bool Validate(Mode mode)
    {
        bool retVal = true;
        retVal = base.Validate(mode);
        if (StartedUsingOn < DateTime.Now)
        {
            retVal = false;
            Errors.Add(nameof(StartedUsingOn), "Started using date cannot be in the past.");
        }
        return retVal;
    }

    public static implicit operator Location(Dal.Entities.LocationEntity entity)
    {
        if (entity == null) return null!;
        return new Location
        {
            Id = entity.Id,
            Name = entity.Description,
            LocationRowId = entity.LocationRowId,
            RackNo = entity.RackNo,
            StartedUsingOn = entity.StartedUsingOn
        };
    }
    public static implicit operator Dal.Entities.LocationEntity(Location location)
    {
        if (location == null) return null!;
        return new Dal.Entities.LocationEntity
        {
            Id = location.Id,
            Description = location.Name,
            LocationRowId = location.LocationRowId,
            RackNo = location.RackNo,
            StartedUsingOn = location.StartedUsingOn
        };
    }
}
