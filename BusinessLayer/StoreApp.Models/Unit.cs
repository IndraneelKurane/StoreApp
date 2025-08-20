using StoreApp.Models.Base;

namespace StoreApp.Models;
public class Unit : BusinessModel<Unit>
{
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public static implicit operator Unit(Dal.Entities.UnitEntity entity)
    {
        if (entity == null) return null!;
        return new Unit
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
    public static implicit operator Dal.Entities.UnitEntity(Unit unit)
    {
        if (unit == null) return null!;
        return new Dal.Entities.UnitEntity
        {
            Id = unit.Id,
            Name = unit.Name,
        };
    }
}
