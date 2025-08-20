using StoreApp.Dal.Entities.Base;

namespace StoreApp.Dal.Entities;

public class ItemEntity : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
    public decimal Amount { get; set; }
    public int UnitId { get; set; }
    public int LocationId { get; set; }

    // Navigation properties
    public UnitEntity? Unit { get; set; } = default!;
    public LocationEntity Location { get; set; } = default!;
    public ICollection<BillItemEntity> BillItems { get; set; } = new List<BillItemEntity>();
}
