using StoreApp.Dal.Entities.Base;

namespace StoreApp.Dal.Entities;

public class UnitEntity : EntityBase
{
    public string Name { get; set; } = default!;

    // Navigation properties
    public ICollection<ItemEntity> Items { get; set; } = new List<ItemEntity>();
}

