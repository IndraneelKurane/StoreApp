using StoreApp.Dal.Entities.Base;

namespace StoreApp.Dal.Entities;

public class LocationRowEntity : EntityBase
{

    public string Name { get; set; } = string.Empty;
    public bool InUse { get; set; }
    // Navigation properties
    public ICollection<LocationEntity> Locations { get; set; } = new List<LocationEntity>();

}