using StoreApp.Dal.Entities.Base;


namespace StoreApp.Dal.Entities;

public class BillItemEntity : EntityBase
{
    public int BillId { get; set; }
    public int ItemId { get; set; }
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Amount { get; set; }

    // Navigation properties
    public BillEntity Bill { get; set; } = default!;
    public ItemEntity Item { get; set; } = default!;
    public ICollection<DeliveryScheduleEntity> DeliverySchedules { get; set; } = new List<DeliveryScheduleEntity>()!;
}
