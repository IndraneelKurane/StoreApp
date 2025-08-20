using StoreApp.Dal.Entities.Base;

namespace StoreApp.Dal.Entities;

public class LocationEntity : EntityBase
{
    public string Description { get; set; } = string.Empty;
    public int LocationRowId { get; set; }
    public int RackNo { get; set; }
    public DateTime StartedUsingOn { get; set; }


    // Navigation properties
    public LocationRowEntity? LocationRow { get; set; } = null!;
    public ICollection<ItemEntity> Items { get; set; } = new List<ItemEntity>();
}
