using StoreApp.Dal.Entities.Base;


namespace StoreApp.Dal.Entities;

public class DeliveryScheduleEntity : EntityBase
{
    public int BillItemId { get; set; }
    public DateTime DeliveryDate { get; set; }
    public Decimal Quantity { get; set; }
    //Navigation properties
    public BillItemEntity BillItem { get; set; } = default!;
}